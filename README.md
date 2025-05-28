# CentricProject

## Descriere

CentricUnitTestProject este un set de teste automate end-to-end pentru aplicația ParaBank (https://parabank.parasoft.com). Proiectul folosește **MSTest** ca framework de testare și **Selenium WebDriver** cu **ChromeDriver** pentru interacțiunea cu browser-ul.

Scopul proiectului este de a valida principalările fluxuri de utilizator:
- Înregistrare, deconectare și autentificare
- Deschidere cont nou (SAVINGS/CHECKING)
- Solicitare împrumut
- Actualizare informații de contact
- Trimitere mesaj către suport

> **Disclaimer Site demo ParaSoft**  
> ParaBank este un site demo folosit pentru demonstrarea soluțiilor software Parasoft.  
> Toate materialele de aici sunt folosite exclusiv pentru simularea unei experiențe realiste de banking online.  
>  
> _Cu alte cuvinte: ParaBank nu este o bancă reală!_  
>  
> Pentru mai multe informații despre soluțiile Parasoft, vizitați www.parasoft.com sau sunați la 888-305-0041  
>  
> *Text citat de pe site-ul Parasoft*


## Detalii despre clase și pachete

### PageObjectModel (POM)
- **RegisterPage.cs**  
  Navighează la pagina de înregistrare, completează formularul cu date generate aleator, trimite și așteaptă confirmarea.

- **LoginPage.cs**  
  Navigare la pagina de autentificare, completarea câmpurilor `username` și `password`, click pe “Log In” și “Log Out”.

- **OpenAccountPage.cs**  
  Accesează “Open New Account”, selectează tipul de cont și contul sursă, deschide contul și returnează noul ID.

- **RequestLoanPage.cs**  
  Navighează la “Request Loan”, completează sumă, perioadă și cont sursă, verifică aprobarea.

- **UpdateInfoPage.cs**  
  Accesează “Update Contact Info”, curăță și actualizează câmpurile de adresă și telefon, așteaptă mesajul de confirmare.

- **ContactPage.cs**  
  Accesează “Contact Us”, completează și trimite formularul de mesaj, verifică afișarea confirmării.

### Tests (MSTest)
- **Workflow_1.cs**  
  Înregistrare → validare mesaj → logout → login cu cont demo.

- **Workflow_2.cs**  
  Deschidere cont nou și solicitare împrumut ca teste separate.

- **Workflow_3.cs**  
  Actualizare informații de contact și trimitere mesaj de suport.

### Pachete NuGet
- `Selenium.WebDriver`  
- `Selenium.Support`  
- `MSTest.TestFramework`  
- `MSTest.TestAdapter`  


