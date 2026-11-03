=============================================================================

SpiegoCodice.vb

===========================================================================



DOCUMENTAZIONE DEL BROWSER DEL CODICE SORGENTE



Questo file è una documentazione "in stile README.md" inserita direttamente

nel progetto VB.NET.



Non contiene logica applicativa: serve per ricordare come è costruito il

Browser del codice e come funzionano le sue parti principali.



===========================================================================

1. OBIETTIVO

===========================================================================



Il Browser del codice permette di:



  - visualizzare l'albero delle cartelle e dei file VB.NET;

  - selezionare un file .vb;

  - visualizzare il relativo codice sorgente;

  - mostrare i numeri di riga;

  - evidenziare parole chiave, numeri, stringhe e commenti;

  - riconoscere le principali strutture del codice VB.NET;

  - cercare una parola o una key nel codice;

  - mostrare i risultati della ricerca;

  - cliccare sul risultato della ricerca;

  - aprire automaticamente il file interessato;

  - posizionarsi automaticamente sulla riga esatta trovata.



L'ultimo punto è particolarmente importante:



      RICERCA -> RISULTATO -> FILE -> RIGA ESATTA



In questo modo la ricerca non è soltanto un "trova testo", ma diventa uno

strumento di navigazione all'interno del progetto.



===========================================================================

2. STRUTTURA GENERALE

===========================================================================



Il sistema è composto principalmente da una parte VB.NET e da una parte

HTML / JavaScript.



VB.NET

  |

  +-- HtmlHelpBuilder2.vb

  |

  +-- TreeBuilder.vb

  |

  +-- SourceLoader.vb

  |

  +-- VbStructureParser.vb

  |

  +-- VbNode / VbNodeType

  |

  +-- CodeHighlighter.vb

  |

  +-- altre classi di supporto



HTML / JavaScript

  |

  +-- Browser.html

  +-- Browse.js

  +-- style.css



===========================================================================

3. HtmlHelpBuilder2.vb

===========================================================================



È il punto centrale del Browser.



Si occupa principalmente di:



  - inizializzare WebView2;

  - caricare la pagina HTML del Browser;

  - collegare il codice VB.NET con JavaScript;

  - ricevere le richieste provenienti dalla pagina HTML;

  - aprire il file sorgente richiesto;

  - gestire la visualizzazione del codice;

  - partecipare alla navigazione verso la riga richiesta.



In pratica HtmlHelpBuilder2 rappresenta il collegamento tra:



      VB.NET <----> WebView2 <----> HTML / JavaScript



===========================================================================

4. Browse.js

===========================================================================



Browse.js contiene la logica JavaScript del Browser.



Tra le funzioni utilizzate dal Browser sono presenti funzioni per:



  - selezionare un file;

  - aprire/chiudere cartelle;

  - mostrare il codice;

  - gestire la visualizzazione delle righe;

  - andare direttamente ad una determinata riga.



La funzione GotoCode(line) permette di raggiungere una riga precisa.



Il codice sorgente viene normalmente generato con elementi identificabili

tramite ID, ad esempio:



      id="line58"



Quando viene richiesta la riga 58, JavaScript può quindi portare la

visualizzazione direttamente su quell'elemento.



===========================================================================

5. RICERCA DELLE KEY

===========================================================================



La ricerca parte dall'area di ricerca del Browser.



Esempio:



      protezione



Il Browser analizza i file e produce risultati simili a:



      CodeHighlighter.vb

      riga 58

      ' Protezione stringhe



Il risultato è cliccabile.



===========================================================================

6. NAVIGAZIONE DAL RISULTATO DELLA RICERCA

===========================================================================



Questo è il comportamento finale ottenuto.



Quando l'utente clicca sul risultato:



      1. viene individuato il file;



      2. viene individuata la riga;



      3. Browse.js comunica la richiesta;



      4. HtmlHelpBuilder2 riceve la richiesta;



      5. viene aperto il file interessato;



      6. il codice viene visualizzato;



      7. la visualizzazione viene portata alla riga richiesta.



Esempio:



      Ricerca: protezione



      Risultato:

          CodeHighlighter.vb

          riga 58



      Click

          |

          +--> apertura CodeHighlighter.vb

          |

          +--> posizionamento automatico su riga 58



===========================================================================

7. ShowSource

===========================================================================



La funzione JavaScript ShowSource(html) viene utilizzata per inserire nel

pannello del codice l'HTML generato dal sorgente.



Durante la costruzione del codice vengono inoltre preparati i numeri di

riga.



Il risultato è un codice visualizzato in modo navigabile.



===========================================================================

8. ToggleCode

===========================================================================



ToggleCode(header) permette di comprimere o espandere determinate sezioni

del codice, in particolare le sezioni collegate alle [#Region](#Region).



Questo rende più leggibili file VB.NET lunghi.



===========================================================================

9. CodeHighlighter.vb

===========================================================================



Il componente di evidenziazione trasforma il codice sorgente in HTML

evidenziato.



Le categorie gestite comprendono, in base alle regole attualmente presenti:



  - parole chiave VB.NET;

  - numeri;

  - stringhe;

  - commenti;

  - altre categorie definite nelle regole di highlighting.



L'evidenziazione non deve modificare il contenuto logico del sorgente:

serve esclusivamente a migliorarne la lettura nel Browser.



===========================================================================

10. VbStructureParser.vb

===========================================================================



Il parser analizza la struttura del file VB.NET.



Può riconoscere elementi come:



  - Class

  - Module

  - Interface

  - Enum

  - Property

  - Constructor

  - Function / Sub / Method

  - [#Region](#Region)

  - file



La struttura viene rappresentata attraverso i nodi VbNode.



===========================================================================

11. VbNode / VbNodeType

===========================================================================



VbNode rappresenta un elemento della struttura del codice.



Le informazioni principali comprendono:



  - Text

  - Kind

  - Line

  - FilePath

  - Children



Il tipo del nodo permette di distinguere, ad esempio, un file da una

classe, una regione o un metodo.



===========================================================================

12. TreeBuilder.vb

===========================================================================



Costruisce l'albero delle cartelle e dei file mostrato nella parte sinistra

del Browser.



Il risultato è un albero HTML navigabile.



Selezionando un file viene richiesto il caricamento del relativo sorgente.



===========================================================================

13. SourceLoader.vb

===========================================================================



Si occupa del caricamento del file sorgente e della preparazione della

visualizzazione del codice.



Il file viene analizzato, strutturato e trasformato nella rappresentazione

HTML utilizzata dal pannello destro.



===========================================================================

14. style.css

===========================================================================



Contiene la parte grafica del Browser.



Gestisce, tra le altre cose:



  - pannello sinistro;

  - pannello destro;

  - albero delle cartelle;

  - file selezionato;

  - numeri di riga;

  - colori del codice;

  - intestazioni delle Region;

  - risultati della ricerca;

  - cursore e aspetti grafici degli elementi cliccabili.



===========================================================================

15. ARCHITETTURA DELLA COMUNICAZIONE

===========================================================================



Il flusso generale può essere rappresentato così:



      UTENTE

        |

        v

      Browser.html

        |

        v

      Browse.js

        |

        v

      WebView2

        |

        v

      HtmlHelpBuilder2.vb

        |

        +--> SourceLoader

        |

        +--> VbStructureParser

        |

        +--> CodeHighlighter

        |

        v

      Codice sorgente



===========================================================================

16. REGOLA IMPORTANTE PER LE MODIFICHE FUTURE

===========================================================================



Ora che la ricerca e la navigazione file/riga funzionano correttamente,

evitare di modificare le parti già funzionanti senza una necessità precisa.



Le nuove funzioni dovrebbero essere aggiunte sopra questa base stabile.



In particolare, prima di modificare:



      Browse.js

      HtmlHelpBuilder2.vb

      CodeHighlighter.vb



verificare sempre quale funzione già esistente potrebbe essere coinvolta.



===========================================================================

17. STATO ATTUALE DEL PROGETTO

===========================================================================



FUNZIONANTE:



  [OK] Albero delle cartelle

  [OK] Visualizzazione dei file VB.NET

  [OK] Numeri di riga

  [OK] Syntax highlighting

  [OK] Gestione delle Region

  [OK] Ricerca delle key

  [OK] Visualizzazione dei risultati

  [OK] Risultati cliccabili

  [OK] Apertura automatica del file

  [OK] Posizionamento automatico sulla riga trovata



===========================================================================

18. RISULTATO FINALE

===========================================================================



Il Browser non è più soltanto un visualizzatore di file.



È diventato un piccolo Browser del codice sorgente con navigazione diretta.



La caratteristica fondamentale è:



      CERCO UNA KEY

             |

             v

      VEDO I RISULTATI

             |

             v

      CLICCO IL RISULTATO

             |

             v

      SI APRE IL FILE

             |

             v

      VADO DIRETTAMENTE ALLA RIGA



===========================================================================

Fine documentazione

=============================================================================
