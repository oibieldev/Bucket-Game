# 🪣 Bucket Game MVP

A lightweight 2D physics-based arcade game built with **Unity** and **C#** using the modern **Input System** architecture. The core mechanics focus on object tracking, motion constraints, and dynamic spawning.

## 🎮 Core Mechanics

*   **Adaptive Acceleration Movement:** The player controls a bucket bound to the horizontal axis (X-axis) with linear acceleration logic that scales over time.
*   **Dynamic Obstacle Spawning:** Objects spawn at random coordinates above the screen boundary and drop using simulated gravity.
*   **State Machine Boundaries:** Screen boundaries are strictly constrained between `-32` and `32` units using clamping functions to prevent frame jittering.

## ⚙️ Game Rules & Win/Loss Conditions

The game manager enforces strict session state boundaries:
*   🟢 **Win Condition:** Successfully collect **10 falling spheres** inside the bucket.
*   🔴 **Loss Condition:** The spawner automatically terminates execution and triggers a Game Over if **5 spheres** are lost (missed below the screen boundary).

## 🛠️ Tech Stack & Architecture

*   **Game Engine:** Unity 2022.3+ LTS (or newer)
*   **Language:** C# (.NET Core specification)
*   **Input Handling:** Unity New Input System API (`Keyboard.current`)
*   **Patterns Applied:** 
    *   **Singleton Pattern:** Implemented in the `GameManager` architecture to guarantee a single synchronized instance across scene loads with state preservation (`DontDestroyOnLoad`).
    *   **Frame-Rate Independence:** All physics translations and custom accelerations are scaled linearly using `Time.deltaTime` to ensure identical gameplay speed across hardware ranges (e.g., from entry-level laptops to dedicated RX 580 setups).

## 🚀 How to Run locally

1. Ensure you have **Unity Hub** installed via Flatpak/APT on your Linux distribution.
2. Clone this repository using your authenticated SSH key:
   ```bash
   git clone git@github.com:oibieldev/bucket-game.git
   ```
3. Open **Unity Hub**, click **Add**, and select the cloned repository folder.
4. Open the `MainScene` inside the `Assets/Scenes/` directory and press **Play**.

## 🔏 License

This project is part of the `oibieldev` professional back-end and systems architecture portfolio. Free to use for educational purposes.
