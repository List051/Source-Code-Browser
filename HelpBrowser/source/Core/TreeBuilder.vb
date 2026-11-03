
Imports System.IO
Imports System.Text
Imports GdRVideo.VbNode

Public Class TreeBuilder

#Region "Campi privati"

    Private ReadOnly _SourceFolder As String

    Private ReadOnly CartelleEscluse As String() =
    {
        "bin",
        "obj",
        ".git",
        ".github",
        ".vs",
        "Debug",
        "Release"
    }

#End Region

#Region "Costruttore"

    Public Sub New(sourceFolder As String)

        _SourceFolder = sourceFolder

    End Sub

#End Region

#Region "TreeBuilder"


    Public Function BuildTree() As String

        '    'Dim root As VbNode = VbStructureParser.Parse(fileName)

        '    'BuildCodeTree(root, html)

        Return BuildDirectoryTree(_SourceFolder, True)

    End Function

#End Region

#Region "Directory Tree"
    Private Function BuildDirectoryTree(
    cartella As String,
    Optional cartellaRadice As Boolean = False) As String

        Dim sb As New StringBuilder()

        sb.AppendLine("<ul class='tree-root'>")

        ' ==========================
        ' CARTELLE
        ' ==========================

        For Each subFolder As String In Directory.GetDirectories(cartella)

            Dim nomeCartella As String =
            Path.GetFileName(subFolder).Trim()

            If CartellaEsclusa(nomeCartella) Then
                Continue For
            End If

            sb.AppendLine(
            "<li class='folder-item'>")

            sb.AppendLine(
            "<div class='folder-header' onclick='ToggleFolder(this)'>" &
            "<img class='arrow-icon' src='images/arrow_right.png'>" &
            GetFolderIcon(nomeCartella, cartellaRadice) &
            "<span class='folder-name'>" &
            System.Net.WebUtility.HtmlEncode(nomeCartella) &
            "</span></div>")

            sb.AppendLine(
            "<ul class='folder-content'>")

            ' Ricorsione senza creare un nuovo ul-root
            'Dim contenuto As String =
            Dim contenuto As String =
    BuildDirectoryTree(subFolder, False)

            contenuto =
    contenuto.Replace(
        "<ul class='tree-root'>",
        "")

            Dim posizioneFine As Integer =
    contenuto.LastIndexOf("</ul>")

            If posizioneFine >= 0 Then

                contenuto =
        contenuto.Remove(
            posizioneFine,
            5)

            End If

            sb.AppendLine(contenuto)

            sb.AppendLine(
            "</ul>")

            sb.AppendLine(
            "</li>")

        Next


        ' ==========================
        ' FILE
        ' ==========================

        For Each file As String In Directory.GetFiles(cartella)

            Dim estensione As String =
            Path.GetExtension(file).ToLower()

            If estensione = ".vb" OrElse
           estensione = ".html" OrElse
           estensione = ".css" OrElse
           estensione = ".js" Then

                Dim nomeFile As String =
                Path.GetFileName(file)

                Dim percorsoJs As String =
                file.Replace("\", "\\")

                BuildFileNode(
                sb,
                file,
                percorsoJs,
                estensione,
                nomeFile)

            End If

        Next


        sb.AppendLine("</ul>")

        '    File.WriteAllText(
        '"C:\Users\Utente\Documents\VSC\TempTest\TempTest.html",
        'sb.ToString())

        Return sb.ToString()

    End Function
#End Region

#Region "BuildFileNode"

    Private Sub BuildFileNode(
    sb As StringBuilder,
    file As String,
    percorsoJs As String,
    estensione As String,
    nomeFile As String)

        sb.AppendLine("<li class='file-item'>")

        sb.AppendLine(
    "<div class='file-header' " &
    "onclick=""SelectFile('" & percorsoJs & "', this)"">")

        sb.AppendLine(GetFileIcon(estensione))

        sb.AppendLine(
    "<span class='file-name'>" &
    System.Net.WebUtility.HtmlEncode(nomeFile) &
    "</span>")

        sb.AppendLine("</div>")

        sb.AppendLine("</li>")

    End Sub

#End Region

#Region "Icone"

    Private Function GetFolderIcon(
     nomeCartella As String,
     radice As Boolean) As String


        If radice Then

            Return "<img class='tree-icon' src='images/core_.foldersr.png'>"

        Else

            Return "<img class='tree-icon' src='images/folder.png'>"

        End If

    End Function

    Private Function GetFileIcon(
    estensione As String) As String

        Select Case estensione

            Case ".vb"

                Return "<img class='tree-icon' src='images/vb.png'>"

            Case ".html"

                Return "<img class='tree-icon' src='images/html.png'>"

            Case ".css"

                Return "<img class='tree-icon' src='images/css.png'>"

            Case ".js"

                Return "<img class='tree-icon' src='images/js.png'>"

            Case Else
                Return "<img class='tree-icon' src='images/folder.png'>"

        End Select

    End Function
#End Region

#Region "Utility"

    Private Function CartellaEsclusa(
        nomeCartella As String) As Boolean

        For Each esclusa As String In CartelleEscluse

            If String.Equals(
                esclusa,
                nomeCartella,
                StringComparison.OrdinalIgnoreCase) Then

                Return True

            End If

        Next

        Return False

    End Function


#End Region

#Region "BuildCodeTree"

    Private Sub BuildCodeTree(
    nodo As VbNode,
    sb As StringBuilder)

        sb.AppendLine("<li class='code-item'>")

        Dim icona As String = SourceLoader.GetNodeIcon(nodo.Kind)

        Dim headerClass As String = "code-header"

        If nodo.Kind = VbNode.NodeKind.RegionNode Then
            headerClass = "code-header region-header"
        End If


        If nodo.Children.Count > 0 Then

            sb.AppendLine(
            "<div class='" & headerClass & "' onclick='ToggleCodeNode(this)'>")

            sb.AppendLine(
            "<span class='code-arrow'>▶</span>" &
            "<img class='treeicon' src='images/" & icona & "'>" &
            System.Net.WebUtility.HtmlEncode(nodo.Text))

            sb.AppendLine("</div>")


            sb.AppendLine("<ul class='code-children'>")

            For Each figlio In nodo.Children

                BuildCodeTree(figlio, sb)

            Next

            sb.AppendLine("</ul>")


        Else

            sb.AppendLine(
            "<div class='" & headerClass & "'>")

            sb.AppendLine(
            "<span class='code-node'>" &
            "<img class='treeicon' src='images/" & icona & "'>" &
            System.Net.WebUtility.HtmlEncode(nodo.Text) &
            "</span>")

            sb.AppendLine("</div>")

        End If


        sb.AppendLine("</li>")

    End Sub

#End Region

#Region "GetNodeCssClass"
    Private Function GetNodeCssClass(
    nodo As VbNode) As String

        Select Case nodo.Kind

            Case VbNode.NodeKind.ClassNode
                Return "class-node"

            Case VbNode.NodeKind.RegionNode
                Return "region-node"

            Case VbNode.NodeKind.MethodNode
                Return "method-node"

            Case VbNode.NodeKind.PropertyNode
                Return "property-node"

            Case VbNode.NodeKind.EnumNode
                Return "enum-node"

            Case VbNode.NodeKind.InterfaceNode
                Return "interface-node"

            Case Else
                Return "code-node"

        End Select

    End Function
#End Region

End Class

