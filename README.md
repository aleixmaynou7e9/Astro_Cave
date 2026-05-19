# 🚀 Astro Cave

[![Unity](https://img.shields.io/badge/Unity-2D-blue.svg?style=flat&logo=unity)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-green.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)

**Astro Cave** és un videojoc de plataformes en **2D** de desplaçament lateral desenvolupat amb **Unity** i programat en **C#**. L'objectiu és guiar el personatge principal a través d'una cova plena de perills (punxes i enemics), recollir monedes i trobar el **Pic (*Pickaxe*)** perdut per poder guanyar i completar el nivell.

---

## 🎮 Mecàniques i Controls

* **Moviment:** Utilitza les tecles `A` / `D` o les **fletxes direccionals** per moure la nau/personatge a l'esquerra i a la dreta. L'sprite gira automàticament de manera coherent cap a on camines.
* **Salt:** Prem la tecla **Espai** per saltar. El sistema inclou una detecció de seguretat basada en la inclinació del contacte per evitar salts infinits a les parets o sostres.
* **Condició de Victòria:** Troba i toca l'objecte del **Pic** per activar la pantalla de victòria.
* **Condició de Derrota:** Si caus a les punxes o et toquen els enemics fins a perdre tota la salut, la partida finalitzarà.

---

## 🛠️ Arquitectura del Codi (Scripts)

La lògica del joc està repartida de forma modular en els següents scripts en C#:

### 🤠 Jugador i Controls
* **`PlayerController.cs`:** Controla les forces físiques del moviment horitzontal i el salt del jugador mitjançant `Rigidbody2D`, a més de gestionar l'activació de les animacions de córrer (`isRunning`) i saltar (`isJumping`).
* **`JumpTriggerController.cs`:** Un activador auxiliar situat als peus del jugador que ajuda a activar o desactivar la capacitat de salt quan detecta superfícies transitables.
* **`PlayerHealth.cs`:** Rep l'impacte dels enemics i es comunica directament amb el sistema visual de salut per restar punts de vida.

### 👾 Enemics, Perills i Objectes
* **`EnemyMovement.cs`:** Controla el moviment dels enemics amb física 2D. Canvien de direcció de forma automàtica quan col·lideixen amb un objecte amb l'etiqueta `Patrol Point`.
* **`LinearPatrolMovement.cs`:** Permet configurar patrulles lineals cinemàtiques molt versàtils, funcionant tant en eix Vertical (Y) com Horizontal (X).
* **`EnemyDamage.cs`:** Detecta si l'enemic entra en contacte amb el jugador per infligir-li mal.
* **`SpikeDamage.cs`:** Gestiona el mal per contacte amb punxes. Implementa un temporitzador de refredament (`damageCooldown`) perquè el jugador no perdi tota la vida instantàniament mentre es quedi a sobre d'elles.
* **`CoinController.cs`:** En entrar en contacte amb el jugador, reprodueix un efecte de so (`AudioClip`) en format 3D/espacial i es destrueix de l'escena.
* **`PickaxeManager.cs`:** Script clau que detecta quan el jugador agafa el pic i avisa el gestor de la interfície per carregar la pantalla de victòria.

### 📊 Interfície i Sistemes Globals
* **`UI_Manager.cs`:** S'encarrega de la transició i la càrrega de les diferents escenes del joc (`Intro`, `GameScene`, `LoseScene` i `WinScene`).
* **`DiscreteHeartHealth.cs`:** Controla la interfície dels 3 cors de vida de la GUI. Cada cor compta amb 2 punts de vida (salut per sectors), gestionant visualment si el cor està ple, per la meitat o completament buit a través del component `Image.fillAmount`.
* **`BackgroundMusic.cs` / `Persistance.cs`:** Apliquen el patró *Singleton* i l'ordre `DontDestroyOnLoad` per garantir que la música de fons i els elements de control no es dupliquin ni es tallin en reiniciar el nivell o canviar d'escena.
* **`DragAndDrop.cs`:** Permet arrossegar i deixar anar objectes amb el ratolí prenent la posició de la càmera (útil per a puzles o elements interactius).

---

## 📂 Estructura del Projecte

Dins de la carpeta `Assets/`, els fitxers estan organitzats de la següent manera:
* **`Scripts/`:** Tots els fitxers de codi font C# esmentats anteriorment.
* **`Scenes/`:** Conté les quatre escenes clau del flux: `Intro`, `GameScene`, `LoseScene` i `WinScene`.
* **`Prefabs/`:** Objectes configurats a punt per ser reutilitzats, com monedes, punxes, enemics o el pic.

---

## ⚙️ Com obrir i executar el projecte

1. **Clona el repositori a la teva màquina local:**
   ```bash
   git clone [https://github.com/aleixmaynou7e9/Astro_Cave.git](https://github.com/aleixmaynou7e9/Astro_Cave.git)
