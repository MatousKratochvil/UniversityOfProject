### Zadání pro vytvoření modulu HumanResources

V rámci projektu **UniversityOfProject** vytvořte modul s názvem **HumanResources**, který bude sloužit pro správu zaměstnanců univerzity. Tento modul bude zaměřen na implementaci Rich Domain Modelu a aplikaci principů Domain-Driven Designu (DDD).

#### Požadavky:

1. **Implementace doménových modelů**:
   - Vytvořte doménové entity jako **Zamestnanec**, **Profesor**, **AdministrativniPracovnik**, **Oddeleni**, **Kurz** atd.
   - Použijte **Value Objecty** pro zapouzdření hodnot, jako je **Jmeno**, **CisloZamestnance**, případně **Adresa** nebo **KontaktniInformace**.
   - Zajistěte, aby doménové modely obsahovaly jak data, tak chování (metody) související s těmito daty.

2. **Funkcionalita modulu**:
   - **Přidávání a úprava zaměstnanců**: Umožněte vytváření nových zaměstnanců a aktualizaci jejich údajů.
   - **Přiřazení k oddělením**: Implementujte logiku pro přiřazení zaměstnanců k oddělením nebo katedrám.
   - **Správa kurzů**: Umožněte profesorům přidávat a spravovat kurzy, které vyučují.
   - **Výpočet platu**: Implementujte metody pro výpočet platu různých typů zaměstnanců na základě jejich role a dalších parametrů.

3. **Datová vrstva**:
   - Prozatím použijte **in-memory** úložiště (např. kolekce) pro ukládání dat.
   - Navrhněte rozhraní pro repozitáře (Repository pattern), abyste usnadnili budoucí integraci s perzistentním úložištěm (např. databází).

4. **Testování**:
   - Vytvořte **jednotkové testy** pro klíčové části doménové logiky.
   - Zajistěte pokrytí testy pro metody, které obsahují významnou logiku (např. výpočet platu, přidání kurzu).

5. **Dokumentace**:
   - Připravte **README** soubor s popisem modulu, instrukcemi pro spuštění a základním použitím.
   - Zdokumentujte kód pomocí komentářů a případně generujte API dokumentaci (např. pomocí Javadoc).

6. **Struktura projektu**:
   - Udržujte kód čistý a přehledný, dodržujte konvence pojmenování.
   - Rozdělte kód do vhodných balíčků (packages) podle funkčnosti (např. `domain`, `repository`, `service`).

7. **Dodržování principů DDD**:
   - Oddělte doménovou logiku od aplikační a infrastrukturní vrstvy.
   - Používejte **Entity**, **Value Objecty**, **Aggregate Roots**, **Services** a další stavební bloky DDD tam, kde je to vhodné.
   - Zajistěte, aby doménové modely byly **bohaté na chování** a neobsahovaly pouze data.

#### Cíl:

- Vytvořit základní verzi modulu **HumanResources**, která bude funkční a připravená pro další rozšíření.
- Aplikovat principy Rich Domain Modelu a Domain-Driven Designu v praxi.
- Poskytnout platformu pro testování a experimentování s různými koncepty softwarového vývoje v rámci projektu **UniversityOfProject**.

#### Poznámky:

- **Uživatelské rozhraní**: Pro začátek není potřeba vytvářet grafické uživatelské rozhraní. Interakci s modulem můžete demonstrovat pomocí konzolové aplikace nebo testů.
- **Budoucí rozšíření**: Připravte modul tak, aby bylo snadné jej rozšířit o další funkce, jako je integrace s databází, webové rozhraní nebo pokročilejší obchodní logika.
- **Kvalita kódu**: Dbejte na čistotu kódu, správné ošetření výjimek a dodržování principů objektově orientovaného programování (SOLID, DRY, KISS).