Imports System.IO
Imports Siemens.Engineering
Imports Siemens.Engineering.Compiler
Imports Siemens.Engineering.HW
Imports Siemens.Engineering.HW.Features
Imports Siemens.Engineering.SW
Imports Siemens.Engineering.SW.Blocks

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

        EnumerateDevicesInProject(MyProject)
        'For Each device As Device In MyProject.Devices

        '    Console.WriteLine(device.Name.ToString)
        'Next

    End Sub

    Private Shared Sub EnumerateDevicesInProject(ByVal project As Project)
        Dim deviceComposition As DeviceComposition = project.Devices

        For Each device As Device In deviceComposition
            MsgBox(device.Name)
        Next
    End Sub

    ''' <summary>
    ''' Pagina 215
    ''' </summary>
    ''' <param name="project"></param>
    Private Shared Sub AccessSingleDeviceByName(ByVal project As Project)
        Dim deviceComposition As DeviceComposition = project.Devices
        Dim device As Device = deviceComposition.Find("MyDevice")
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


        CType(projectComposition, IEngineeringComposition).Create(GetType(Project), createParameters)


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






    'PLC program blocks

    Private Shared Sub GetBlockGroupOfPLC(ByVal plcsoftware As PlcSoftware)
        Dim blockGroup As PlcBlockSystemGroup = plcsoftware.BlockGroup
    End Sub



    Private Shared Sub systemBlocks(ByVal plcsoftware As PlcSoftware)
        For Each systemGroup As PlcSystemBlockGroup In plcsoftware.BlockGroup.SystemBlockGroups

            For Each group As PlcSystemBlockGroup In systemGroup.Groups
                Dim pbComposition As PlcBlockComposition = group.Blocks

                For Each block As PlcBlock In pbComposition
                    MsgBox(block.Name)
                Next
            Next
        Next
    End Sub

    Private Sub btnSystemBlocks_Click(sender As Object, e As EventArgs) Handles btnSystemBlocks.Click
        systemBlocks(myPlcSoftware)
    End Sub




    ''' <summary>
    ''' Elenca tutti i blocchi
    ''' </summary>
    ''' <param name="plcsoftware"></param>
    Private Shared Sub EnumerateAllBlocks(ByVal plcsoftware As PlcSoftware)
        Dim text As String = ""


        Dim systemGroup As PlcBlockSystemGroup = plcsoftware.BlockGroup
        Dim groupComposition As PlcBlockUserGroupComposition = systemGroup.Groups

        For Each item In groupComposition
            Dim blocks = item.Blocks
            MsgBox(item.Name)
            For Each block In blocks
                GetPlcBlockInformation(block)
            Next

        Next


        'Dim quantity As Integer = plcsoftware.BlockGroup.Blocks.Count
        'MsgBox(quantity)

        'For Each block As PlcBlock In plcsoftware.BlockGroup.Blocks
        '    text &= block.Name & vbCrLf
        'Next
        'MsgBox(text)
    End Sub

    Private Shared Sub AccessASingleBlock(ByVal plcsoftware As PlcSoftware)
        Dim block As PlcBlock = plcsoftware.BlockGroup.Blocks.Find("FC_RB001_T1")

        GetPlcBlockInformation(block)

    End Sub

    Private Shared Sub GetPlcBlockInformation(ByVal plcBlock As PlcBlock)

        Dim compileDate As DateTime = plcBlock.CompileDate
        Dim modifiedDate As DateTime = plcBlock.ModifiedDate
        Dim isConsistent As Boolean = plcBlock.IsConsistent
        Dim blockNumber As Integer = plcBlock.Number
        Dim blockName As String = plcBlock.Name
        Dim programmingLanguage As ProgrammingLanguage = plcBlock.ProgrammingLanguage
        Dim blockAuthor As String = plcBlock.HeaderAuthor
        Dim blockFamily As String = plcBlock.HeaderFamily
        Dim blockTitle As String = plcBlock.HeaderName
        Dim blockVersion As System.Version = plcBlock.HeaderVersion

        Dim blockinfo As String = ""

        blockinfo &= "compileDate " & compileDate.ToString & vbCrLf
        blockinfo &= "modifiedDate " & modifiedDate.ToString & vbCrLf
        blockinfo &= "isConsistent " & isConsistent.ToString & vbCrLf
        blockinfo &= "blockNumber " & blockNumber.ToString & vbCrLf
        blockinfo &= "blockName " & blockName.ToString & vbCrLf
        blockinfo &= "programmingLanguage " & programmingLanguage.ToString & vbCrLf
        blockinfo &= "blockAuthor " & blockAuthor.ToString & vbCrLf
        blockinfo &= "blockFamily " & blockFamily.ToString & vbCrLf
        blockinfo &= "blockTitle " & blockTitle.ToString & vbCrLf
        blockinfo &= "blockVersion " & blockVersion.ToString & vbCrLf
        blockinfo &= "compileDate " & compileDate.ToString & vbCrLf
        blockinfo &= "compileDate " & compileDate.ToString & vbCrLf

        MsgBox(blockinfo)

    End Sub


    Private Sub btnAllBlocks_Click(sender As Object, e As EventArgs) Handles btnAllBlocks.Click
        EnumerateAllBlocks(myPlcSoftware)
    End Sub

    Private Sub btnSingleBlock_Click(sender As Object, e As EventArgs) Handles btnSingleBlock.Click
        AccessASingleBlock(myPlcSoftware)
    End Sub

    Private Sub btnCreateGroup_Click(sender As Object, e As EventArgs) Handles btnCreateGroup.Click
        CreateBlockGroup(myPlcSoftware)
    End Sub


    Private Shared Sub CreateBlockGroup(ByVal plcsoftware As PlcSoftware)
        Dim systemGroup As PlcBlockSystemGroup = plcsoftware.BlockGroup
        Dim groupComposition As PlcBlockUserGroupComposition = systemGroup.Groups
        Dim myCreatedGroup As PlcBlockUserGroup = groupComposition.Create("MySubGroupName")

    End Sub


End Class
