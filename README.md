
<p align="center"> <img src="Logo.png" alt="Ital Pascal Logo" width="220"> </p>

<p align="center"> <a href="https://www.nuget.org/packages/WinItalPascal"> <img src="https://img.shields.io/nuget/v/WinItalPascal?style=for-the-badge" alt="NuGet Version"> </a> <a href="https://www.nuget.org/packages/WinItalPascal"> <img src="https://img.shields.io/nuget/dt/WinItalPascal?style=for-the-badge" alt="NuGet Downloads"> </a> <img src="https://img.shields.io/github/stars/List051?style=for-the-badge" alt="Stars"> <img src="https://img.shields.io/github/forks/List051/WinItalPascal_Lib?style=for-the-badge" alt="Forks"> <img src="https://img.shields.io/github/issues/List051/WinItalPascal_Lib?style=for-the-badge" alt="Issues"> <img src="https://img.shields.io/github/last-commit/List051/WinItalPascal_Lib?style=for-the-badge" alt="Last Commit"> <a href="https://github.com/List051/WinItalPascal_Lib/blob/main/License.txt"> <img src="https://img.shields.io/github/license/List051/WinItalPascal_Lib?style=for-the-badge" alt="License"> </a> </p>

# 🧩 WinItalPascal – Source Code Browser

## Descrizione

Il **Source Code Browser** è uno strumento integrato nel progetto VB.NET che permette di esplorare, visualizzare e navigare il codice sorgente in modo semplice e intuitivo.

Non è un semplice visualizzatore di file: consente di cercare parole chiave nel codice e raggiungere direttamente il file e la riga corrispondente al risultato.

## 📘  Funzionalità principali

- **Esplorazione del progetto:** visualizzazione ad albero di cartelle e file VB.NET.
- **Visualizzazione del codice:** apertura e lettura dei file sorgente.
- **Numerazione delle righe:** identificazione precisa delle righe di codice.
- **Syntax Highlighting:** evidenziazione di parole chiave, stringhe, numeri e commenti.
- **Gestione delle Region:** possibilità di comprimere ed espandere sezioni del codice.
- **Analisi strutturale:** riconoscimento di Class, Module, Interface, Enum, Property, Function, Sub e altri elementi VB.NET.
- **Ricerca delle parole chiave:** individuazione dei termini all'interno dei file sorgente.
- **Navigazione intelligente:** apertura automatica del file e posizionamento sulla riga esatta del risultato selezionato.

## 🔧 Architettura

Il Browser utilizza un'architettura ibrida **VB.NET + HTML + JavaScript**, basata su WebView2.

|Componente|Descrizione|
|---|---|
|`HtmlHelpBuilder2.vb`|Gestisce WebView2 e la comunicazione tra VB.NET e JavaScript.|
|`TreeBuilder.vb`|Costruisce l'albero delle cartelle e dei file.|
|`SourceLoader.vb`|Carica e prepara il codice sorgente.|
|`VbStructureParser.vb`|Analizza la struttura dei file VB.NET.|
|`VbNode / VbNodeType`|Rappresentano gli elementi strutturali del codice.|
|`CodeHighlighter.vb`|Genera il codice HTML con syntax highlighting.|
|`Browser.html`|Definisce l'interfaccia del Browser.|
|`Browse.js`|Gestisce interazioni, visualizzazione e navigazione alle righe.|
|`style.css`|Gestisce l'aspetto grafico dell'interfaccia.|

## 📇 Ricerca e navigazione

La caratteristica principale è il collegamento diretto tra ricerca e navigazione nel codice.

Il funzionamento è il seguente:

text

```
RICERCA PAROLA CHIAVE
        |
        v
VISUALIZZAZIONE RISULTATI
        |
        v
SELEZIONE DEL RISULTATO
        |
        v
APERTURA AUTOMATICA DEL FILE
        |
        v
POSIZIONAMENTO SULLA RIGA ESATTA
```

Ad esempio, cercando `protezione`, il Browser può individuare un risultato in `CodeHighlighter.vb`, riga 58.

Selezionando il risultato, il file viene aperto automaticamente e la visualizzazione viene portata direttamente alla riga interessata.

## 🧰 Tecnologie utilizzate

- VB.NET
- HTML5
- CSS3
- JavaScript
- Microsoft WebView2

## 🏷️ Stato del progetto

<badge color="success">Funzionalità principali implementate</badge>

- [ ] Albero delle cartelle e dei file
- [ ] Visualizzazione del codice VB.NET
- [ ] Numerazione delle righe
- [ ] Syntax Highlighting
- [ ] Gestione delle Region
- [ ] Analisi della struttura del codice
- [ ] Ricerca delle parole chiave
- [ ] Visualizzazione dei risultati
- [ ] Risultati cliccabili
- [ ] Apertura automatica del file
- [ ] Navigazione diretta alla riga trovata

## 🗃️ Note per gli sviluppi futuri

Le funzionalità di ricerca e navigazione costituiscono una base già funzionante.

Eventuali modifiche a `Browse.js`, `HtmlHelpBuilder2.vb` e `CodeHighlighter.vb` dovrebbero essere effettuate con attenzione, verificando prima le dipendenze dalle funzionalità esistenti.

Si consiglia di mantenere stabile il flusso:

**Ricerca → Risultato → File → Riga esatta**

---

> ## 🔖 Obiettivo
> 
> Trasformare la consultazione del codice sorgente in un'esperienza di navigazione rapida, strutturata e intuitiva, permettendo di passare da una semplice parola chiave direttamente al punto del codice in cui viene utilizzata.


---

<div align="center">
  <h2>⭐ Come supportare il progetto</h2>
  <p>Se questo progetto ti è utile, puoi supportarlo con un semplice gesto:</p>

  <!-- Pulsante Star -->
  <a href="https://github.com/List051/FrameWork_WinItalPascal_2_0_2">
    <img src="https://img.shields.io/github/stars/List051/FrameWork_WinItalPascal_2_0_2?style=social" alt="Star this repo">
  </a>

  <!-- Pulsante Fork -->
  <a href="https://github.com/List051/FrameWork_WinItalPascal_2_0_2/fork">
    <img src="https://img.shields.io/github/forks/List051/FrameWork_WinItalPascal_2_0_2?label=fork&style=social" alt="Fork this repo">
  </a>

  <p>Mettere una ⭐ o fare un Fork aiuta il progetto a crescere e permette ad altri sviluppatori di scoprirlo.</p>

  <br>

  <!-- Pulsante Follow autore -->
  <p>Vuoi restare aggiornato sui nuovi progetti?</p>

  <a href="https://github.com/List051">
    <img src="https://img.shields.io/github/followers/List051?label=Follow%20%40List051&style=social" alt="Follow @List051">
  </a>

  <p>Grazie per il tuo supporto!</p>
</div>

---