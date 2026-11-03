Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Public NotInheritable Class CodeHighLight


#Region "Keyword VB"

    Private Shared ReadOnly _Keywords As String() =
    {
        "AddHandler", "AddressOf", "Alias", "And", "AndAlso",
        "As", "Boolean", "ByRef", "Byte", "ByVal",
        "Call", "Case", "Catch", "Char", "Class",
        "Const", "Continue", "Decimal", "Declare",
        "Default", "Delegate", "Dim", "DirectCast",
        "Do", "Double", "Each", "Else",
        "ElseIf", "End", "Enum", "Erase",
        "Event", "Exit", "False", "Finally",
        "For", "Friend", "Function", "Get",
        "GetType", "Global", "GoSub", "GoTo",
        "Handles", "If", "Implements", "Imports",
        "In", "Inherits", "Integer", "Interface",
        "Is", "IsNot", "Long", "Loop",
        "Me", "Mod", "Module", "MustInherit",
        "MustOverride", "MyBase", "MyClass",
        "Namespace", "New", "Next", "Not",
        "Nothing", "Object", "Of", "On",
        "Option", "Optional", "Or", "OrElse",
        "Overrides", "Overridable", "Partial",
        "Private", "Property", "Protected",
        "Public", "RaiseEvent", "ReadOnly",
        "ReDim", "RemoveHandler", "Return",
        "Select", "Set", "Shared", "Short",
        "Single", "Static", "Step", "Stop",
        "String", "Structure", "Sub", "Then",
        "Throw", "To", "True", "Try",
        "TryCast", "TypeOf", "UInteger",
        "ULong", "UShort", "Using",
        "While", "With", "WriteOnly",
        "Xor"
    }

#End Region

#Region "Metodo pubblico"

    Public Shared Function HighlightVB(
        source As String) As String

        If String.IsNullOrEmpty(source) Then
            Return ""
        End If

        Dim strings As New List(Of String)

        Dim comments As New List(Of String)

        ' Protezione stringhe

        Dim text As String =
            ProtectStrings(source, strings)

        ' Protezione commenti

        text =
            ProtectComments(text, comments)

        ' Escape HTML

        text =
            EscapeHtml(text)

        ' Evidenzia keyword

        text =
            HighlightKeywords(text)

        ' Ripristino commenti

        text =
            RestoreTokens(
                text,
                comments,
                "___COMMENT_")

        ' Ripristino stringhe

        text =
            RestoreTokens(
                text,
                strings,
                "___STRING_")

        Return text

    End Function

#End Region

#Region "Protezione stringhe"

    Private Shared Function ProtectStrings(
        text As String,
        list As List(Of String)) As String

        Return Regex.Replace(
            text,
            """([^""\r\n]|"""")*""",
            Function(m)

                Dim index As Integer =
                    list.Count

                list.Add(m.Value)

                Return "___STRING_" &
                       index &
                       "___"

            End Function)

    End Function

#End Region

#Region "Protezione commenti"

    Private Shared Function ProtectComments(
        text As String,
        list As List(Of String)) As String

        Return Regex.Replace(
            text,
            "'[^\r\n]*",
            Function(m)

                Dim index As Integer =
                    list.Count

                list.Add(m.Value)

                Return "___COMMENT_" &
                       index &
                       "___"

            End Function,
            RegexOptions.Multiline)

    End Function

#End Region

#Region "Escape HTML"

    Private Shared Function EscapeHtml(
        text As String) As String

        Return text _
            .Replace("&", "&amp;") _
            .Replace("<", "&lt;") _
            .Replace(">", "&gt;")

    End Function

#End Region

#Region "Keyword"

    ' ==========================================
    ' HighlightKeywords - Versione definitiva
    ' Agosto 2026
    ' Sostituisce il vecchio algoritmo basato su
    ' Regex.Replace() multipli.
    ' ==========================================

    Private Shared Function HighlightKeywords(
    text As String) As String

        Dim sb As New StringBuilder()

        Dim i As Integer = 0

        While i < text.Length

            Dim ch As Char = text(i)

            ' ==========================================
            ' Numeri
            ' ==========================================

            If Char.IsDigit(ch) Then

                Dim start As Integer = i

                i += 1

                While i < text.Length AndAlso
                (Char.IsDigit(text(i)) OrElse text(i) = "."c)

                    i += 1

                End While

                Dim number As String =
                text.Substring(start, i - start)

                sb.Append("<span class=""number"">")
                sb.Append(number)
                sb.Append("</span>")

                ' ==========================================
                ' Identificatori / Keyword / Classi
                ' ==========================================

            ElseIf Char.IsLetter(ch) OrElse ch = "_"c Then

                Dim start As Integer = i

                i += 1

                While i < text.Length AndAlso
                (Char.IsLetterOrDigit(text(i)) OrElse
                 text(i) = "_"c)

                    i += 1

                End While

                Dim word As String =
                text.Substring(start, i - start)

                '------------------------------------------
                ' Classe (identificatore seguito da ".")
                '------------------------------------------

                If i < text.Length AndAlso text(i) = "."c Then

                    sb.Append("<span class=""class-name"">")
                    sb.Append(word)
                    sb.Append("</span>")

                Else

                    Dim isKeyword As Boolean = False

                    For Each kw As String In _Keywords

                        If String.Equals(
                        kw,
                        word,
                        StringComparison.OrdinalIgnoreCase) Then

                            isKeyword = True
                            Exit For

                        End If

                    Next

                    If isKeyword Then

                        sb.Append("<span class=""keyword"">")
                        sb.Append(word)
                        sb.Append("</span>")

                    Else

                        sb.Append(word)

                    End If

                End If

                ' ==========================================
                ' Tutto il resto
                ' ==========================================

            Else

                sb.Append(ch)
                i += 1

            End If

        End While

        Return sb.ToString()

    End Function


#End Region

#Region "Ripristino Token"

    Private Shared Function RestoreTokens(
        text As String,
        list As List(Of String),
        prefix As String) As String

        For i As Integer = 0 To list.Count - 1

            Dim token As String =
                prefix &
                i &
                "___"

            Dim value As String = (list(i))
            '  EscapeHtml(list(i))

            If prefix.Contains("COMMENT") Then

                value =
                    "<span class=""comment"">" &
                    value &
                    "</span>"
            Else
                value =
                    "<span class=""string"">" &
                    value &
                    "</span>"
            End If

            text =
                text.Replace(
                    token,
                    value)
        Next
        Return text
    End Function

#End Region


#Region "Highlight con numerazione righe"

    Public Shared Function HighlightVBWithLines(
        source As String) As String

        Dim sb As New StringBuilder()

        Dim lines() As String =
            source.Split(
                {vbCrLf, vbLf},
                StringSplitOptions.None)

        For i As Integer = 0 To lines.Length - 1

            Dim lineHtml As String =
                HighlightVB(lines(i))

            Dim cssClass As String = ""

            Dim testo As String =
                lines(i).TrimStart()

            If testo.StartsWith("#Region", StringComparison.OrdinalIgnoreCase) OrElse
               testo.StartsWith("#End Region", StringComparison.OrdinalIgnoreCase) Then

                cssClass = " class=""region-line"""

            End If

            ' Usare Append senza AppendLine per evitare newline tra i div
            sb.Append(
                "<div id=""line" &
                (i + 1).ToString() &
                """" &
                cssClass &
                ">" &
                lineHtml &
                "</div>")

        Next

        Return sb.ToString()

    End Function

#End Region

End Class