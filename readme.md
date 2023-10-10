# Borelli_BdT

## Introduzione

La ‘Banca del Tempo’ (BdT) indica uno di quei sistemi organizzati di persone che si associano per scambiare servizi e/o saperi, attuando un aiuto reciproco.
Attraverso la BdT le persone mettono a disposizione il proprio tempo per determinate prestazioni (effettuare una piccola riparazione in casa, preparare una torta, conversare in lingua straniera, ecc.) aspettando di ricevere prestazioni da altri.
Non circola denaro, tutte le prestazioni sono valutate in tempo, anche le attività di segreteria.
Le prestazioni sono suddivise in categorie (lavori manuali, tecnologie, servizi di trasporto, bambini, attività sportive, ecc.). Chi dà un’ora del suo tempo a qualunque socio, riceve un’ora di tempo da chiunque faccia parte della BdT.
La struttura dati dovrà mantenere le informazioni relative ad ogni prestazione (quale prestazione, da chi è stata erogata, quale socio ha ricevuto quella prestazione, per quante ore e in quale data) per consentire anche interrogazioni di tipo statistico.
Il territorio di riferimento della BdT è limitato (un quartiere in una grande città o un piccolo comune) ed è suddiviso in zone; la struttura dati dovrà contenere i riferimenti alla mappa del territorio e alle singole zone, in modo da poterla visualizzare graficamente.

### Utente di default

Il programma dispone di un utente di default, con permessi di segretario, in assenza di file con utenti già esistente.
Nome utente: `DummyNickName`
Password: `password`

### Livelli utente

Esistono 3 gradi di permessi:

1. `Base`: solitamente quello associato alla maggior parte degli utenti, permette all'utente di poter esclusivamente richiedere-accettare una task, visualizzare i profili altrui...
2. `Secretary`: questo livello, concesso solo ai segretari, permette di sbloccare diverse funzioni:
   - Accettare gli utenti la cui richiesta è in sospeso;
   - Concedere agli utenti il permesso di segretario;
   - Avere a disposizione altre tab da cui poter ricavare statistiche riguardo utenti e task.
3. `Admin`: dispone di tutti i permessi sopra elencati. Non è però ora utilizzato. [PER SCOPI FUTURI]

### Registrazione di un nuovo utente

La registrazione di un nuovo utente non è immediata. È divisa in due step:

- Nel primo step l'utente inserisce nella form dedicata i propri dati, tra cui la lista dei lavori disposto a fare e la lista dei quartieri in cui è disposto  a lavorare. Queste ultime due hanno però la possibilità di ricevere in input non solo i lavori/le zone già esistenti ma anche nuovi valori;
- Nel secondo step viene richiesta la convalida dell'account da parte di un segretario. Se sono stati aggiunti nuovi lavori/zone in fase di registrazione e il segretario li ritiene appropriati li aggiungerà alla lista definitiva dei lavori (i prossimi utenti che si registreranno li vedranno) e convaliderà l'iscrizione.

### Task

Per richiedere una task bisogna andare nella tab dedicata, selezionare il tipo di lavoro richiesto, inserire una descrizione se si vuole e premere il tasto per richiedere.
La richiesta non sempre viene accettata. Se la differenza percentuale tra le ore donate e le ore richieste è maggiore rispetto ad un tot (stabilito dal segretario) allora non si potrà fare richiesta.
Finché la task non viene presa in carico da nessuno, il richiedente può annullarne la richiesta o modificarne la descrizione.
Una volta accettata si entra in una nuova fase. La task può infatti essere lasciata dall'accettante solo se il richiedente non ha già completato i campi di fine task. Se questo dovesse avvenire la task verrà considerata come completata.
I campi da compilare al termine della task sono: valutazione in stelle, data di inizio, data di fine, durata in ore e recensione scritta (opzionale).

### TODO

Restano ancora al momento in sospeso alcuni TODO:

1. La task non può ancora essere eliminata se si trova ancora in fase di richiesta;
2. L'utente non può ancora modificare i propri dati (aggiornandolo ad esempio con nuovi lavori e zone disponibili);
3. Quando una task viene richiesta come zona viene assunta quella di abitazione del richiedente. Bisogna fare in modo che anche la zona si possa personalizzare;
4. Non si possono ancora inserire, in fase di creazione dell'account, nuove zone in cui si è disposti a lavorare;
5. La possibilità di ordinare le colonne delle varie liste in base al click sulla colonna interessata.
6. La possibilità di un reset password da parte del segretario nei confronti di un profilo utente. Al momento quando il segretario apre in modifica l'account di un utente può ancora modificarne tutti i dati (da rimuovere).
7. Tasto logout e scelta da parte dell'utente del tema (per modificarlo manualmente: `utilities/FormManager`: `Init()` e poi ricompilare).
8. Password criptate.