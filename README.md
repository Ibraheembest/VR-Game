# VR Burgerito Game 🎮🔥  

## Overview  
**VR Grill Master** is an interactive and immersive virtual reality game where players take on the role of a chef at a grill station. Using XR technologies, players cook and serve food while managing tasks like flipping steaks, preparing hamburgers, and earning points to level up.  

The game leverages Unity’s **XR Interaction Toolkit** to provide intuitive and realistic interactions with in-game objects, ensuring an engaging experience for players.

---

![bg](https://github.com/user-attachments/assets/6c0719a5-35a7-4fb9-aaa4-212afc81594c)


## Features  
- **Dynamic Cooking System:**  
  - Real-time material changes (e.g., "Cooked" and "Burned") based on player actions.  
  - Simulates realistic grill interactions with flames and sound effects.  

- **Level Progression System:**  
  - Earn points by selling hamburgers to customers.  
  - Score targets to unlock higher levels with increased challenges.  

- **Interactive Objects:**  
  - Toggle flames using knobs.  
  - Replace items on the table with hamburgers after a delay.  

- **Immersive Audio and Visual Feedback:**  
  - Realistic sound effects (e.g., cash register, grill sounds).  
  - Particle systems for flames and detailed material changes.

---

## Getting Started  

### Prerequisites  
- **Unity Version:** 2021.3 or later (recommended)  
- **XR Interaction Toolkit:** Version 2.3 or later  
- Compatible VR headset (e.g., Oculus, HTC Vive)  

### Installation  
1. Clone this repository:  
   ```bash  
   git clone https://github.com/yourusername/VR-Grill-Master.git  
   cd VR-Grill-Master  
   ```  
2. Open the project in Unity.  
3. Ensure your XR headset is connected and set up in Unity using the XR Interaction Toolkit.  

### Scene Hierarchy  
Here’s a snapshot of the project’s scene hierarchy:  
![bg](https://github.com/user-attachments/assets/d92112cc-1ed4-4ef2-ad6e-8ec88c48c133)



---

## Gameplay Mechanics  

### Scripts Breakdown  

#### 1. **BreadChangeColor.cs**  
- Handles material changes for "Cube 2" after colliding with "Cube 1."  
- Changes material to "Well Done" after a delay of 5 seconds.  

#### 2. **CashierInteraction.cs**  
- Tracks player score and level progression.  
- Plays cash register sound when hamburgers are sold.  
- Displays a level transition screen after reaching the score target.  

#### 3. **CubeColorChange.cs**  
- Simulates cooking progression with material changes (Cooked → Burned).  
- Plays grill sound while the steak is cooking.  

#### 4. **KnobFlameToggle.cs**  
- Toggles flame particle system on and off.  
- Controls the grill sound associated with flame state.  

#### 5. **TableInteraction.cs**  
- Replaces items on the table with a hamburger after a 60-second delay.  
- Clears all items before spawning the new hamburger prefab.  

---

## How to Play  
1. **Prepare Food:**  
   - Place items on the grill and wait for the appropriate cooking time.  
   - Monitor material changes to avoid burning food.  

2. **Serve Customers:**  
   - Deliver cooked food (e.g., hamburgers) to customers.  
   - Earn points for each successful delivery.  

3. **Level Up:**  
   - Reach the score target to progress to the next level.  
   - Take on new challenges with higher difficulty.  

---

## Assets Used  
- **XR Interaction Toolkit**  
- **Particle Systems:** For flames and visual effects.  
- **Custom Materials:** Used for different states like "Cooked" and "Burned."  
- **Audio Effects:** Grill and cash register sounds.  

---

## Controls  
- **VR Controller:**  
  - Use triggers to interact with objects.  
  - Grab and release items with the grip button.  
- **Knobs:** Toggle flames by interacting with the grill knobs.  

---

## Known Issues  
- Items may occasionally not align perfectly on the table.  
- Grill sound may overlap if flame toggling is spammed.  

---

## Future Improvements  
- Add more food items and recipes.  
- Implement a time-based scoring bonus.  
- Include customer feedback for enhanced realism.  

---

## Contributing  
Contributions are welcome!  
1. Fork this repository.  
2. Create a new branch:  
   ```bash  
   git checkout -b feature-name  
   ```  
3. Commit your changes:  
   ```bash  
   git commit -m "Add new feature"  
   ```  
4. Push to the branch:  
   ```bash  
   git push origin feature-name  
   ```  
5. Open a pull request.  

---

## License  
This project is licensed under the MIT License. See the `LICENSE` file for details.  

