La classe deve essere **indipendente dal nome del controllo**. Non deve sapere nulla di `RichTextBox6`, `RichTextBox1`, ecc.

Il modo corretto è passare il controllo come **parametro**.

Esempio:

### Classe `HelpFormatter.vb`

```vb
Imports System.Drawing
Imports System.Windows.Forms

Public Class HelpFormatter

    Public Shared Sub AddNote(rtb As RichTextBox, testo As String)

        With rtb

            ' Titolo NOTE
            .SelectionBackColor = Color.LightSteelBlue
            .SelectionColor = Color.Navy
            .SelectionFont = New Font("Segoe UI", 10, FontStyle.Bold)

            .AppendText(" NOTE ")
            .AppendText(vbCrLf)

            ' Corpo
            .SelectionBackColor = Color.White
            .SelectionColor = Color.RoyalBlue
            .SelectionFont = New Font("Segoe UI", 10, FontStyle.Bold)

            .AppendText("▶ ")

            .SelectionColor = Color.Black
            .SelectionFont = New Font("Segoe UI", 10)

            .AppendText(testo)

            .AppendText(vbCrLf & vbCrLf)

        End With

    End Sub


    Public Shared Sub AddTitle(rtb As RichTextBox, titolo As String)

        With rtb

            .SelectionColor = Color.DarkBlue
            .SelectionFont = New Font("Segoe UI", 12, FontStyle.Bold)

            .AppendText(titolo)

            .AppendText(vbCrLf & vbCrLf)

        End With

    End Sub


    Public Shared Sub AddNew(rtb As RichTextBox, testo As String)

        With rtb

            .SelectionColor = Color.Green
            .SelectionFont = New Font("Segoe UI", 10, FontStyle.Bold)

            .AppendText("★ ")

            .SelectionColor = Color.Black
            .AppendText(testo)

            .AppendText(vbCrLf)

        End With

    End Sub

End Class
```

---

## Uso in qualsiasi Form

Nel tuo caso:

```vb
HelpFormatter.AddNote(RichTextBox6,
    "Il modulo Help (ModHelp.vb) è già disponibile nella libreria locale.")
```

In un altro form:

```vb
HelpFormatter.AddNote(RichTextBox1,
    "Nuova funzione inserita.")
```

oppure:

```vb
HelpFormatter.AddTitle(RichTextBox3,
    "Database")
```

---

## Ancora meglio: permettere anche di scegliere il colore

Versione più flessibile:

```vb
Public Shared Sub AddMessage(
        rtb As RichTextBox,
        icona As String,
        testo As String,
        colore As Color)

    With rtb

        .SelectionColor = colore
        .SelectionFont = New Font("Segoe UI", 10, FontStyle.Bold)
        .AppendText(icona & " ")

        .SelectionColor = Color.Black
        .SelectionFont = New Font("Segoe UI", 10)
        .AppendText(testo)

        .AppendText(vbCrLf)

    End With

End Sub
```

Utilizzo:

```vb
HelpFormatter.AddMessage(
    RichTextBox6,
    "▶",
    "Modulo Help aggiunto",
    Color.RoyalBlue)
```

oppure:

```vb
HelpFormatter.AddMessage(
    RichTextBox1,
    "★",
    "Nuova versione disponibile",
    Color.DarkOrange)
```

---

Questo approccio si integra bene con la tua libreria **WinItalPascal**: 
`ModHelp.vb` diventa un componente riutilizzabile e non è legato a nessun Form specifico.
