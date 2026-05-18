# CiclistApp — Evidență Trasee Ciclism

Aplicație desktop WinForms în C# pentru gestionarea bicicliștilor și a traseelor parcurse de aceștia, cu persistență în SQLite.

---

## Cerințe

- Visual Studio 2019+ (sau orice versiune cu suport .NET Framework 4.7.2)
- .NET Framework 4.7.2
- Pachetele NuGet sunt incluse în folderul `packages/` — nu necesită restaurare manuală

---

## Rulare

1. Deschide `CiclistApp.slnx` în Visual Studio
2. Apasă `F5` sau `Ctrl+F5`
3. La prima rulare, baza de date `ciclism.db` se creează automat în directorul executabilului (`bin\Debug\`)

---

## Structura bazei de date

### Biciclisti
| Coloană       | Tip     | Constrângere              |
|---------------|---------|---------------------------|
| id_biciclist  | INTEGER | PRIMARY KEY AUTOINCREMENT |
| nume          | TEXT    | NOT NULL                  |
| cnp           | TEXT    | NOT NULL                  |

### Trasee
| Coloană         | Tip     | Constrângere                              |
|-----------------|---------|-------------------------------------------|
| id_traseu       | INTEGER | PRIMARY KEY AUTOINCREMENT                 |
| id_biciclist    | INTEGER | NOT NULL, FOREIGN KEY → Biciclisti        |
| denumire_traseu | TEXT    | NOT NULL                                  |
| distanta_km     | REAL    | NOT NULL                                  |
| dificultate     | TEXT    | NOT NULL (ușor / mediu / dificil)         |
| durata_estimata | INTEGER | NOT NULL (minute)                         |

---

## Funcționalități implementate

| Cerință | Implementare |
|---|---|
| Baza de date relațională cu FK | `Database.cs` → `InitDB()` |
| Adăugare biciclist | GroupBox "Adaugă Biciclist" + buton Adaugă |
| Afișare bicicliști în ListBox | `lstBiciclist` — se actualizează la fiecare operație |
| Adăugare traseu pentru biciclistul selectat | GroupBox "Adaugă Traseu" — activ doar cu selecție |
| Afișare trasee în DataGridView | `dvgTrasee` — se reîncarcă la selecție biciclist |
| Validare CNP (exact 13 caractere) | `Validators.ValidateCnp()` |
| Validare nume (nu poate fi gol) | `Validators.ValidateNume()` |
| Validare distanță (> 0) | `Validators.ValidateDistanta()` |
| Validare durată (> 0) | `Validators.ValidateDurata()` |
| Traseu fără biciclist selectat blocat | verificare `GetSelectedBiciclistId()` |
| Căutare biciclist după CNP | GroupBox "Caută după CNP" → selectează automat în ListBox |
| Statistici biciclist selectat | GroupBox "Statistici Biciclist Selectat": nr. trasee, distanță totală, cel mai lung traseu |
| Ștergere traseu + actualizare UI | Buton "Șterge Traseu Selectat" cu confirmare |
| Detalii traseu în PropertyGrid | `pgDetalisTraseu` — se populează la selecție rând în grid |
| Statistici generale | GroupBox "Statistici Generale": total bicicliști, total trasee |
| Persistență date | SQLite — toate datele sunt salvate permanent în `ciclism.db` |

---

## Structura proiectului

```
CiclistApp/
├── Program.cs          — entry point
├── Form1.cs            — logica interfeței (evenimente, load, statistici)
├── Form1.Designer.cs   — layout generat de Designer
├── Database.cs         — DatabaseHelper + clasa Biciclist
├── Models.cs           — clasa TraseuDetalii (folosită în PropertyGrid)
├── Validators.cs       — validări de input
└── App.config          — configurație aplicație
```
