
/*
HtmlHelpBuilder2
Browser JavaScript
*/

/* =====================================================
Selezione file VB
===================================================== */

function SelectFile(filePath, element) {

    document.querySelectorAll(".file-item").forEach(function (item) {

        item.classList.remove("selected");

    });


    if (element) {

        element.classList.add("selected");

    }


    if (window.chrome &&
        window.chrome.webview) {

        window.chrome.webview.postMessage(filePath);

    }


}

/* =====================================================
Apertura / chiusura cartelle
===================================================== */

function ToggleFolder(element) {


    let content =
        element.nextElementSibling;


    let arrow =
        element.querySelector(".arrow-icon");


    let folder =
        element.querySelector(".tree-icon");


    if (!content) {

        return;

    }


    let aperta =
        content.style.display !== "none";


    if (aperta) {

        content.style.display = "none";


        if (arrow) {

            arrow.src =
                "images/arrow_right.png";

        }


        if (folder) {

            folder.src =
                "images/folder.png";

        }


    }
    else {

        content.style.display = "block";


        if (arrow) {

            arrow.src =
                "images/arrow_down.png";

        }


        if (folder) {

            folder.src =
                "images/folder_aperta.png";

        }

    }


}

/* =====================================================
Visualizzazione codice sorgente

Riceve HTML già evidenziato da VB.NET
===================================================== */

function ShowSource(html) {

    const viewer = document.getElementById("sourceCode");
    const numbers = document.getElementById("lineNumbers");
    if (!viewer || !numbers) return;

    // Conteggio delle linee dall'HTML (conta anche div vuoti)
    const matches = (html.match(/<div\s+id=["']line\d+["']/g) || []).length;

    // Inserisco l'HTML evidenziato (CodeHighLight genera <div id="lineN"> per riga)
    viewer.innerHTML = html;

    // Caratteristiche di stile per calcolare altezza di riga e padding
    const comp = getComputedStyle(viewer);
    let lineHeight = parseFloat(comp.lineHeight);
    if (isNaN(lineHeight)) {
        const fontSize = parseFloat(comp.fontSize) || 14;
        lineHeight = fontSize * 1.4;
    }
    const paddingTop = parseFloat(comp.paddingTop) || 0;

    // Conteggio affidabile basato sugli elementi effettivamente renderizzati
    const lineElems = viewer.querySelectorAll('[id^="line"]');
    const domCount = lineElems.length;

    // Numero righe effettivo: considerare anche i div vuoti presenti nell'HTML
    const lineCount = Math.max(domCount, matches);

    // Costruisco elementi numeri con altezza coerente per evitare disallineamenti
    numbers.innerHTML = ""; // reset
    numbers.style.paddingTop = paddingTop + "px";

    const frag = document.createDocumentFragment();
    for (let i = 0; i < lineCount; i++) {
        const div = document.createElement("div");
        div.textContent = (i + 1).toString();
        div.style.height = lineHeight + "px";
        div.style.lineHeight = lineHeight + "px";
        div.style.padding = "0";
        div.style.margin = "0";
        div.style.whiteSpace = "nowrap";
        div.style.textAlign = "right";
        frag.appendChild(div);
    }
    numbers.appendChild(frag);

    SyncLineScroll();
}



/* =====================================================
Sincronizzazione scroll numeri di riga
===================================================== */

function SyncLineScroll() {


    let code =
        document.getElementById("sourceCode");


    let numbers =
        document.getElementById("lineNumbers");


    if (!code || !numbers) {

        return;

    }


    if (
        code.dataset.scrollAttached ===
        "true"
    ) {

        return;

    }


    code.dataset.scrollAttached =
        "true";


    code.addEventListener(
        "scroll",
        function () {

            numbers.scrollTop =
                code.scrollTop;

        }
    );


}

/* =====================================================
Test comunicazione WebView2
==================================================== */


/* =====================================================
Caricamento albero
===================================================== */

function ShowTree(html) {


    let tree =
        document.getElementById(
            "directoryTree"
        );


    if (!tree) {

        return;

    }


    tree.innerHTML =
        html;


    document.querySelectorAll(
        ".folder-content"
    )
        .forEach(function (folder) {

            folder.style.display =
                "none";

        });


    let primaCartella =
        document.querySelector(
            ".folder-header"
        );


    if (primaCartella) {

        let contenuto =
            primaCartella.nextElementSibling;


        let icona =
            primaCartella.querySelector(
                ".folder-icon"
            );


        if (contenuto) {

            contenuto.style.display =
                "block";

        }


        if (icona) {

            icona.textContent =
                "▼";

        }

    }


}

/* =====================================================
Nome file corrente
===================================================== */

function ShowFileName(nome) {


    let title =
        document.getElementById(
            "fileTitle"
        );


    if (title) {

        title.textContent =
            "📄 " + nome;

    }


}

/* =====================================================
Apertura nodi codice
===================================================== */

function ToggleCode(header) {


    const children =
        header.nextElementSibling;


    if (!children)
        return;


    children.classList.toggle(
        "collapsed"
    );


    const arrow =
        header.querySelector(
            ".code-arrow"
        );


    if (!arrow)
        return;


    arrow.textContent =
        children.classList.contains(
            "collapsed"
        )
            ? "▶"
            : "▼";


}

/* =====================================================
Visualizzazione struttura codice

Riceve HTML da SourceLoader
===================================================== */

function ShowCodeTree(html) {


    let tree =
        document.getElementById(
            "codeTree"
        );


    if (!tree) {

        return;

    }


    tree.innerHTML =
        html;

}

/* =====================================================
Apertura nodo codice
===================================================== */

function GotoCode(line) {


    console.log(
        "CLICK LINEA:",
        line
    );


    let element =
        document.getElementById(
            "line" + line
        );


    if (element) {

        element.scrollIntoView({
            behavior: "smooth",
            block: "center"
        });

    }
    else {

        if (
            window.chrome &&
            window.chrome.webview
        ) {

            window.chrome.webview.postMessage(
                "Form1.vb"
            );

        }


        console.log(
            "NON TROVATO line" + line
        );

    }


}

/* =====================================================
RICERCA
===================================================== */

/* =====================================================
Avvio ricerca
===================================================== */


function EseguiRicerca() {

    let input =
        document.getElementById(
            "searchInput"
        );


    if (!input) {

        console.error(
            "RICERCA: searchInput non trovato"
        );

        return;

    }


    let testo =
        input.value.trim();


    console.log(
        "RICERCA:",
        testo
    );


    if (
        window.chrome &&
        window.chrome.webview
    ) {

        window.chrome.webview.postMessage(
            "RICERCA:" + testo
        );

    }
    else {

        console.error(
            "RICERCA: WebView2 non disponibile"
        );

    }

}



/* =====================================================
Visualizzazione risultati ricerca
===================================================== */

function ShowSearchResults(html) {


    let risultati =
        document.getElementById(
            "searchResultsContent"
        );


    if (!risultati) {

        console.error(
            "RICERCA: searchResultsContent non trovato"
        );

        return;

    }


    risultati.innerHTML =
        html;


}

/* =====================================================
Inizializzazione barra ricerca
===================================================== */

function InitSearch() {

    let input =
        document.getElementById(
            "searchInput"
        );


    let button =
        document.getElementById(
            "searchButton"
        );


    if (!input || !button) {

        return;

    }


    if (
        input.dataset.searchAttached ===
        "true"
    ) {

        return;

    }


    input.dataset.searchAttached =
        "true";


    button.onclick =
        function () {

            EseguiRicerca();

        };


    input.onkeydown =
        function (event) {

            if (
                event.key ===
                "Enter"
            ) {

                EseguiRicerca();

            }

        };

}
function RicercaDiretta() {

    let input =
        document.getElementById(
            "searchInput"
        );


    if (!input) {

        return;

    }


    let testo =
        input.value.trim();


    if (
        window.chrome &&
        window.chrome.webview
    ) {

        window.chrome.webview.postMessage(
            "RICERCA:" + testo
        );

    }

}


/*test per RicercaDiretta*/
// Rendilo globale in modo che onclick="RicercaDiretta()" lo trovi
window.RicercaDiretta = function () {
    var input = document.getElementById('searchInput');
    var valore = input ? input.value : '';
    // Log locale
    console.log('RicercaDiretta valore:', valore);
    // Invia al host (WebView2)
    if (window.chrome && window.chrome.webview && window.chrome.webview.postMessage) {
        // Modifica browser.js: invia JSON stringificato
        window.chrome.webview.postMessage(JSON.stringify({ action: 'RicercaDiretta', query: valore }));
    } else {
        // Fallback: puoi gestire la ricerca nella pagina stessa
        alert('Valore ricerca: ' + valore);
    }
};

// Aggiungi il listener dopo che il DOM è pronto
document.addEventListener('DOMContentLoaded', function () {
    var btn = document.getElementById('searchButton');
    if (btn) {
        btn.addEventListener('click', function () {
            RicercaDiretta();
        });
    }
});

// funzione globale per aprire file e andare a riga
window.OpenFileAndGoto = function (filePath, line) {
    if (window.chrome && window.chrome.webview && window.chrome.webview.postMessage) {
        window.chrome.webview.postMessage({ action: 'OpenFileAndGoto', path: filePath, line: line });
    } else {
        console.error('OpenFileAndGoto: WebView2 non disponibile');
    }
};