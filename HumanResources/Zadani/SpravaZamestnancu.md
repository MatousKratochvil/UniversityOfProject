# Podrobné zadání pro Správu zaměstnanců

## Úvod

Cílem této části je detailně popsat požadavky na systém pro správu zaměstnanců v rámci modulu Personálního oddělení univerzitního systému. Systém umožní efektivní evidenci, úpravu a správu informací o zaměstnancích, což zlepší procesy personalistiky a usnadní práci uživatelům.

## Funkční požadavky

### 1. Registrace nového zaměstnance

- **Vstupní údaje**:
    - Osobní informace: jméno, příjmení, datum narození, rodné číslo.
    - Kontaktní údaje: adresa, telefonní číslo, e-mail.
    - Pracovní informace: pozice, oddělení, nadřízený, pracovní smlouva (typ, délka).
    - Platové údaje: platová třída, základní mzda, bonusy.
- **Proces**:
    - Uživatel s odpovídajícím oprávněním vyplní formulář s údaji nového zaměstnance.
    - Systém ověří unikátnost rodného čísla a e-mailu.
    - Po úspěšném uložení systém vygeneruje zaměstnanecké ID a případně přístupové údaje.
- **Výstup**:
    - Nový záznam v databázi zaměstnanců.
    - Odeslání uvítacího e-mailu zaměstnanci s přístupovými údaji (pokud je relevantní).

### 2. Úprava údajů zaměstnance

- **Vstupní údaje**:
    - Aktualizované informace o zaměstnanci.
- **Proces**:
    - Uživatel vyhledá zaměstnance podle jména, ID nebo jiného kritéria.
    - Upraví potřebné údaje ve formuláři.
    - Systém zaznamená změny a uloží je.
- **Výstup**:
    - Aktualizovaný záznam zaměstnance.
    - Záznam změn pro auditní účely.

### 3. Odstranění/deaktivace zaměstnance

- **Vstupní údaje**:
    - Zaměstnanecké ID nebo jiný identifikátor.
- **Proces**:
    - Uživatel může zaměstnance označit jako neaktivního (např. při ukončení pracovního poměru).
    - Úplné odstranění záznamu je možné pouze s vyšším oprávněním a po potvrzení.
- **Výstup**:
    - Aktualizovaný status zaměstnance (aktivní/neaktivní).
    - Archivace dat při odstranění.

### 4. Vyhledávání a filtrování

- **Vstupní údaje**:
    - Kritéria vyhledávání: jméno, oddělení, pozice, status, datum nástupu atd.
- **Proces**:
    - Uživatel zadá kritéria do vyhledávacího pole nebo použije pokročilé filtrování.
    - Systém zobrazí seznam odpovídajících zaměstnanců.
- **Výstup**:
    - Seznam zaměstnanců s možností další akce (zobrazení detailu, editace).

### 5. Hromadné operace

- **Funkce**:
    - Hromadná aktualizace údajů (např. zvýšení platu v určitém oddělení).
    - Hromadný import/export zaměstnanců pomocí CSV nebo Excel souborů.
- **Proces**:
    - Uživatel vybere zaměstnance nebo importuje soubor.
    - Potvrdí akci a systém provede požadované změny.
- **Výstup**:
    - Aktualizované záznamy.
    - Report o provedených změnách.

### 6. Role a oprávnění

- **Role uživatelů**:
    - Administrátor: plný přístup ke všem funkcím.
    - Personalista: správa zaměstnanců, ale omezený přístup k citlivým datům.
    - Manažer: přístup k zaměstnancům ve svém oddělení.
- **Proces**:
    - Systém kontroluje oprávnění při každé akci.
- **Výstup**:
    - Zabezpečený přístup podle definovaných rolí.

### 7. Notifikace a upozornění

- **Funkce**:
    - Upozornění na končící smlouvy.
    - Připomínky pro dokončení povinných školení.
- **Proces**:
    - Systém automaticky generuje upozornění na základě dat.
- **Výstup**:
    - Zobrazení notifikací v systému nebo odeslání e-mailem.

### 8. Reporty a statistiky

- **Funkce**:
    - Generování reportů o počtu zaměstnanců, fluktuaci, průměrném platu atd.
- **Proces**:
    - Uživatel vybere typ reportu a nastaví parametry.
    - Systém vygeneruje report ve formátu PDF nebo Excel.
- **Výstup**:
    - Stažitelný soubor s reportem.

## Nefunkční požadavky

- **Uživatelská přívětivost**: Jednoduché a intuitivní ovládání, konzistentní design.
- **Bezpečnost**: Soulad s GDPR, šifrování citlivých dat, pravidelné zálohy.
- **Výkon**: Rychlá odezva při vyhledávání a ukládání dat, optimalizace pro velké množství záznamů.
- **Dostupnost**: Systém dostupný 24/7, minimalizace výpadků.
- **Podpora více jazyků**: Možnost přepínat mezi jazykovými mutacemi (např. čeština, angličtina).

## Datový model

### Hlavní entity

- **Zaměstnanec**
    - ID
    - Jméno
    - Příjmení
    - Datum narození
    - Rodné číslo
    - Adresa
    - Telefon
    - E-mail
    - Status (aktivní/neaktivní)
    - Datum nástupu
    - Datum ukončení
    - Pozice_ID
    - Oddělení_ID
    - Nadřízený_ID

- **Oddělení**
    - ID
    - Název
    - Popis
    - Vedoucí_ID

- **Pozice**
    - ID
    - Název
    - Popis
    - Platová třída

- **Plat**
    - Zaměstnanec_ID
    - Základní mzda
    - Bonusy
    - Datum platnosti

### Vztahy mezi entitami

- **Zaměstnanec** 1:N **Oddělení** (zaměstnanec patří do jednoho oddělení)
- **Zaměstnanec** 1:N **Pozice** (zaměstnanec může mít více pozic v historii)
- **Zaměstnanec** 1:N **Plat** (platové změny v čase)

## Uživatelské rozhraní

### Navigace

- **Hlavní menu**: Dashboard, Zaměstnanci, Oddělení, Reporty, Nastavení.
- **Podmenu** v sekci Zaměstnanci: Seznam zaměstnanců, Přidat zaměstnance, Import/Export.

### Seznam zaměstnanců

- Tabulka s možností:
    - Třídění podle sloupců.
    - Filtrování dle kritérií.
    - Akcí u každého záznamu (zobrazení detailu, editace, deaktivace).

### Formulář zaměstnance

- **Záložky**:
    - Osobní údaje.
    - Pracovní údaje.
    - Platové údaje.
    - Dokumenty (smlouvy, certifikáty).
- **Validace**:
    - Povinná pole označena hvězdičkou.
    - Kontrola formátu e-mailu, telefonního čísla atd.

### Notifikační centrum

- Přehled všech upozornění.
- Možnost označit jako přečtené nebo odstranit.

## Bezpečnost

- **Autentizace**:
    - Přihlášení pomocí uživatelského jména a hesla.
    - Možnost dvoufaktorové autentizace.
- **Autorizace**:
    - Přístupová práva definovaná rolemi.
    - Logování všech přístupů a akcí uživatelů.
- **Šifrování**:
    - Šifrování citlivých dat v databázi.
    - SSL/TLS pro komunikaci mezi klientem a serverem.
- **Ochrana proti útokům**:
    - Prevence SQL Injection, XSS.
    - Ochrana proti CSRF (Cross-Site Request Forgery).

## Testování

### Testovací scénáře

- **Funkční testy**:
    - Registrace nového zaměstnance.
    - Úprava a deaktivace zaměstnance.
    - Vyhledávání a filtrování.
- **Uživatelské testy**:
    - Testování uživatelského rozhraní na intuitivnost.
- **Zátěžové testy**:
    - Simulace velkého počtu uživatelů a záznamů.
- **Bezpečnostní testy**:
    - Penetrační testy.
    - Kontrola souladu s bezpečnostními standardy.

## Integrace s dalšími systémy

- **Docházkový systém**:
    - Synchronizace údajů o zaměstnancích.
    - Import dat o docházce pro výpočet mezd.
- **Mzdový systém**:
    - Přenos platových údajů.
    - Automatizace výpočtu mezd a odvodů.
- **E-learningový systém**:
    - Evidence absolvovaných školení.
    - Notifikace o povinných kurzech.

## Dokumentace

- **Uživatelská příručka**:
    - Návody pro běžné uživatele.
    - FAQ sekce.
- **Technická dokumentace**:
    - Popis architektury systému.
    - API dokumentace pro integrace.
- **Záznamy změn**:
    - Log změn ve verzích systému.

## Závěr

Toto podrobné zadání poskytuje nezbytný základ pro návrh a vývoj systému pro správu zaměstnanců. Důraz je kladen na funkčnost, bezpečnost a uživatelskou přívětivost. Další kroky zahrnují tvorbu prototypu, iterativní vývoj s průběžným testováním a finální nasazení systému do provozu.