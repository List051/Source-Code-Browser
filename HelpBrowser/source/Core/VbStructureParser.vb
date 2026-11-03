Imports System.IO
Imports System.Text.RegularExpressions
Imports GdRVideo.VbNode

Public Class VbStructureParser

#Region "Parse"


    Public Shared Function Parse(fileName As String) As VbNode

        Dim root As New VbNode With {
        .Text = Path.GetFileName(fileName),
        .Kind = NodeKind.File,
        .Line = 1,
        .FilePath = fileName
    }

        Dim stack As New Stack(Of VbNode)

        stack.Push(root)

        Dim lineNumber As Integer = 0
        For Each line As String In File.ReadLines(fileName)

            lineNumber += 1

            ParseLine(line.Trim(), lineNumber, stack)

        Next


        AssignFilePath(root, fileName)


        Return root

        'For Each line As String In File.ReadLines(fileName)

        '    lineNumber += 1

        '    ParseLine(line.Trim(), lineNumber, stack)

        'Next

        'Return root

    End Function

#End Region
#Region "ParseLine"

    Private Shared Sub ParseLine(
    text As String,
    line As Integer,
    stack As Stack(Of VbNode))

        If text = "" Then Return

        If text.StartsWith("#Region") Then

            Dim n As New VbNode With {
            .Kind = NodeKind.RegionNode,
            .Text = text,
            .Line = line
        }

            stack.Peek.Children.Add(n)
            stack.Push(n)

            Return

        End If

        If text.StartsWith("#End Region") Then

            If stack.Count > 1 Then stack.Pop()

            Return

        End If

#End Region

#Region "Class"

        Dim m As Match

            m = Regex.Match(text,
                "^(Public |Friend |Private |Protected )?(Partial )?Class\s+([A-Za-z0-9_]+)",
                RegexOptions.IgnoreCase)

            If m.Success Then

            Dim n As New VbNode With {
                    .Kind = NodeKind.ClassNode,
                    .Text = m.Groups(3).Value,
                    .Line = line
                }

            stack.Peek.Children.Add(n)
                stack.Push(n)

                Return

            End If
#End Region

#Region "Module"
        m = Regex.Match(text,
        "^(Public )?Module\s+([A-Za-z0-9_]+)",
        RegexOptions.IgnoreCase)

            If m.Success Then

            Dim n As New VbNode With {
            .Kind = NodeKind.ModuleNode,
            .Text = m.Groups(2).Value,
            .Line = line
        }

            stack.Peek.Children.Add(n)
                stack.Push(n)

                Return

            End If

            If text.Equals("End Class", StringComparison.OrdinalIgnoreCase) OrElse
   text.Equals("End Module", StringComparison.OrdinalIgnoreCase) Then

                If stack.Count > 1 Then stack.Pop()

                Return

            End If
#End Region


#Region "Method"

        m = Regex.Match(text,
        "(Public |Private |Friend |Protected |Protected Friend )?(Shared )?(Overloads )?(Overrides )?(Sub|Function)\s+([A-Za-z0-9_]+)",
        RegexOptions.IgnoreCase)

        If m.Success Then

            Dim n As New VbNode With {
                .Kind = NodeKind.MethodNode,
                .Text = m.Groups(6).Value,
                .Line = line
            }

            stack.Peek.Children.Add(n)

            Return

        End If

#End Region
#Region "Constructor"
        m = Regex.Match(text,
        "(Public |Private )?Sub\s+New",
        RegexOptions.IgnoreCase)

            If m.Success Then

            stack.Peek.Children.Add(New VbNode With {
            .Kind = NodeKind.ConstructorNode,     ' Questo è uno dei 6 errori
            .Text = "New",
            .Line = line
        })

        End If

End Sub
#End Region

#Region "TEST Dump"
    Public Shared Function Dump(root As VbNode) As String

        Dim sb As New System.Text.StringBuilder

        DumpNode(root, sb, 0)

        Return sb.ToString()

    End Function

    Private Shared Sub DumpNode(
        node As VbNode,
        sb As System.Text.StringBuilder,
        level As Integer)

        sb.AppendLine(New String(" "c, level * 4) & node.Text)

        For Each child In node.Children
            DumpNode(child, sb, level + 1)
        Next

    End Sub

    Private Shared Sub AssignFilePath(
    nodo As VbNode,
    fileName As String)

        nodo.FilePath = fileName

        For Each figlio As VbNode In nodo.Children

            AssignFilePath(figlio, fileName)

        Next

    End Sub
#End Region
End Class