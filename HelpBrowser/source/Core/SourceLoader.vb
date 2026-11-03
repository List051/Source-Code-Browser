Imports System.IO
Imports System.Text

Public Class SourceLoader

    Public Shared Function LoadFile(
        percorso As String) As String

        If Not File.Exists(percorso) Then
            Return "File non trovato: " & percorso
        End If


        Dim estensione As String =
            Path.GetExtension(percorso).ToLower()


        Select Case estensione

            Case ".vb"

                Dim root As VbNode =
                    VbStructureParser.Parse(percorso)

                Dim sb As New StringBuilder()

                sb.AppendLine("<ul class='code-tree'>")

                RenderCodeNode(root, sb)

                sb.AppendLine("</ul>")


                '   MessageBox.Show("Genera File HTML disabilitata.")

                '            File.WriteAllText(
                '"C:\Users\Utente\Documents\VSC\TempTest\TempTest.html",
                'sb.ToString())

                Return sb.ToString()


            Case Else

                Return File.ReadAllText(percorso)

        End Select

    End Function

#Region "RenderCodeNode"

    Private Shared Sub RenderCodeNode(
    nodo As VbNode,
    sb As StringBuilder)

        sb.AppendLine("<li class='code-item'>")


        Dim headerClass As String = "code-header"

        If nodo.Kind = VbNode.NodeKind.RegionNode Then
            headerClass = "code-header region-header"
        End If


        If nodo.Children.Count > 0 Then

            sb.AppendLine("<div class='" & headerClass & "'>")

            sb.AppendLine(
        "<img class='code-arrow' src='images/legend.png' " &
        "onclick='ToggleCode(this.parentElement); event.stopPropagation();'>" &
        "<span class='code-node' onclick='GotoCode(" & nodo.Line & "); event.stopPropagation();'>" &
        "<img class='treeicon' src='images/" & GetNodeIcon(nodo.Kind) & "'>" &
        System.Net.WebUtility.HtmlEncode(nodo.Text) &
        "</span>")

            sb.AppendLine("</div>")

            sb.AppendLine("<ul class='code-children collapsed'>")

            For Each figlio As VbNode In nodo.Children
                RenderCodeNode(figlio, sb)
            Next

            sb.AppendLine("</ul>")

        Else

            sb.AppendLine("<div class='" & headerClass & "'>")

            sb.AppendLine(
        "<span class='code-placeholder'></span>" &
        "<span class='code-node' onclick='GotoCode(" & nodo.Line & "); event.stopPropagation();'>" &
        "<img class='treeicon' src='images/" & GetNodeIcon(nodo.Kind) & "'>" &
        System.Net.WebUtility.HtmlEncode(nodo.Text) &
        "</span>")

            sb.AppendLine("</div>")

        End If

        sb.AppendLine("</li>")

    End Sub

#End Region



#Region "GetNodeIcon"
    ' Private Function GetNodeIcon(node As VbNode) As String
    Public Shared Function GetNodeIcon(kind As VbNode.NodeKind) As String

        Select Case kind

            Case VbNode.NodeKind.ClassNode
                Return "dialog.png"

            Case VbNode.NodeKind.ModuleNode
                Return "notes_pin.png"

            Case VbNode.NodeKind.RegionNode
                Return "red_line.png"

            Case VbNode.NodeKind.MethodNode
                Return "cog_go.png"

            Case VbNode.NodeKind.PropertyNode
                Return "tag_green.png"

            Case VbNode.NodeKind.ConstructorNode
                Return "star.png"

            Case VbNode.NodeKind.EnumNode
                Return "key.png"

            Case VbNode.NodeKind.InterfaceNode
                Return "legend.png"

            Case Else
                Return "vb.png"

        End Select

    End Function
#End Region


End Class