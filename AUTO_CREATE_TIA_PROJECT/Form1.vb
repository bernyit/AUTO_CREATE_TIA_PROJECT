Imports System.IO
Imports Siemens.Engineering
Imports Siemens.Engineering.Compiler
Imports Siemens.Engineering.HW
Imports Siemens.Engineering.HW.Features
Imports Siemens.Engineering.SW

Public Class Form1


    Private MyTiaPortal As TiaPortal
    Private MyProject As Project
    Private MyDevice As Device
    Private myPlcSoftware As PlcSoftware
    Dim ProjectPath As String = ""

    Private Sub btnOpenTia15_Click(sender As Object, e As EventArgs) Handles btnOpenTia15.Click
        MyTiaPortal = New TiaPortal(TiaPortalMode.WithUserInterface)
    End Sub

    Private Sub btnCloseTia15_Click(sender As Object, e As EventArgs) Handles btnCloseTia15.Click
        MyTiaPortal.Dispose()
    End Sub

    Private Sub btnOpenTia15Project_Click(sender As Object, e As EventArgs) Handles btnOpenTia15Project.Click
        Dim fileSearch As OpenFileDialog = New OpenFileDialog

        fileSearch.Filter = "*.ap15|*.ap15"
        fileSearch.RestoreDirectory = True
        fileSearch.ShowDialog()

        ProjectPath = fileSearch.FileName.ToString()

        If String.IsNullOrEmpty(ProjectPath) = False Then

            Try

                MyProject = MyTiaPortal.Projects.Open(New FileInfo(ProjectPath))
                txt_Status.Text = "Project " + ProjectPath + " opened"

            Catch ex As Exception
                txt_Status.Text = "Error while opening project" + ex.Message

            End Try
        End If
    End Sub

    Private Sub btnCloseTia15Project_Click(sender As Object, e As EventArgs) Handles btnCloseTia15Project.Click
        MyProject.Close()
    End Sub

    Private Sub btnIterateDevices_Click(sender As Object, e As EventArgs) Handles btnIterateDevices.Click

        MsgBox(MyProject.Devices.Count)

        If MyProject.Devices.Count > 0 Then

            MyDevice = MyProject.Devices(0)
            myPlcSoftware = GetPlcSoftware(MyDevice)
        End If


        'For Each device As Device In MyProject.Devices

        '    Console.WriteLine(device.Name.ToString)
        'Next

    End Sub



    ' 
    ''' <summary>
    ''' Pagina 165
    ''' </summary>
    ''' <param name="device"></param>
    ''' <returns>Returns PlcSoftware</returns>
    Private Function GetPlcSoftware(ByVal device As Device) As PlcSoftware
        Dim deviceItemComposition As DeviceItemComposition = device.DeviceItems

        For Each deviceItem As DeviceItem In deviceItemComposition
            Dim softwareContainer As SoftwareContainer = deviceItem.GetService(Of SoftwareContainer)()

            If softwareContainer IsNot Nothing Then
                Dim softwareBase As Software = softwareContainer.Software
                Dim plcSoftware As PlcSoftware = TryCast(softwareBase, PlcSoftware)
                Return plcSoftware
            End If
        Next

        Return Nothing
    End Function



    Private Sub btnSaveTia15Project_Click(sender As Object, e As EventArgs) Handles btnSaveTia15Project.Click
        MyProject.Save()
    End Sub

    Private Sub btnCreateProject_Click(sender As Object, e As EventArgs) Handles btnCreateProject.Click
        createProjectWithOptionalParameters()
    End Sub

    Private Sub createProjectWithStandardParameters()
        Dim projectComposition As ProjectComposition = MyTiaPortal.Projects
        Dim targetDirectory As DirectoryInfo = New DirectoryInfo("D:\TiaProjects")
        ' Create a project with name MyProject
        Dim project As Project = projectComposition.Create(targetDirectory, "MyProject")

    End Sub

    Private Sub createProjectWithOptionalParameters()
        Dim projectComposition As ProjectComposition = MyTiaPortal.Projects
        'Dim createParameters As New Dictionary(Of String, Object)

        ' Create a project with both mandatory And optional parameters

        'Pagina 102 del manuale, in C#... come si converte?
        '(IEngineeringComposition)projectComposition).Create(TypeOf (Project), createParameters)
        Dim createParameters As IEnumerable(Of KeyValuePair(Of String, Object)) = {
            New KeyValuePair(Of String, Object)("TargetDirectory", New DirectoryInfo("D:\TiaProjects")),  ' Mandatory
            New KeyValuePair(Of String, Object)("Name", "progettoCreatoAutomaticamente"),  ' Mandatory
            New KeyValuePair(Of String, Object)("Author", "Giovanni"), ' Optional 
            New KeyValuePair(Of String, Object)("Comment", "This project was created with Openness ")} ' Optional 


        CType(ProjectComposition, IEngineeringComposition).Create(GetType(Project), createParameters)


    End Sub



    ''' <summary>
    ''' Pagina 114 del manuale
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnProjectProperties_Click(sender As Object, e As EventArgs) Handles btnProjectProperties.Click

        If ReferenceEquals(MyProject, Nothing) = False Then
            Dim author As String = MyProject.Author
            Dim Name As String = MyProject.Name
            Dim Path As String = MyProject.Path.ToString
            Dim creationTime As DateTime = MyProject.CreationTime
            Dim modificationTime As DateTime = MyProject.LastModified
            Dim lastModifiedBy As String = MyProject.LastModifiedBy
            Dim Version As String = MyProject.Version
            'Dim comment As MultilingualText = MyProject.Comment
            Dim copyright As String = MyProject.Copyright
            Dim family As String = MyProject.Family
            Dim Size As Int64 = MyProject.Size
            'Dim LanguageSettings As LanguageSettings = Project.LanguageSettings

            Dim testo As String = ""

            testo &= "author " & author & vbCrLf
            testo &= "Name " & Name & vbCrLf
            testo &= "Path " & Path & vbCrLf
            testo &= "creationTime " & creationTime & vbCrLf
            testo &= "modificationTime " & modificationTime & vbCrLf
            testo &= "lastModifiedBy " & lastModifiedBy & vbCrLf
            testo &= "Version " & Version & vbCrLf
            'testo &= "" & comment & vbCrLf
            testo &= "copyright " & copyright & vbCrLf
            testo &= "family " & family & vbCrLf
            testo &= "Size " & Size & vbCrLf

            MsgBox(testo)

        Else
            MsgBox("progetto non aperto")
        End If




    End Sub







    Public Sub CompilePlcSoftware(plcSoftware As PlcSoftware)

        Dim compileService As ICompilable = plcSoftware.GetService(Of ICompilable)
        Dim result As CompilerResult = compileService.Compile()
    End Sub

    Private Sub btnCompile_Click(sender As Object, e As EventArgs) Handles btnCompile.Click
        CompilePlcSoftware(myPlcSoftware)
    End Sub
End Class
