# Wood-You-Roll

**Wood-You-Roll** is a Unity 3D game featuring a challenging, multi-level structure. The game involves navigating a rolling ball through complex paths, dynamic obstacles, and strategic teleportation points, providing an engaging experience for players looking to test their reflexes and puzzle-solving skills.

![Screenshot 2024-09-28 at 10 02 28 PM](https://github.com/user-attachments/assets/b329f640-6a78-4bf7-9c7a-b645f3be52b6)

## Features

1. **Two-Level Game Design**
   - **Level 1**: A beginner-friendly layout to learn basic controls.
   - **Level 2**: Includes longer paths, moving platforms, and narrower areas for a more complex challenge.

2. **Dynamic Ball Size Manipulation**  
   - Ball size changes dynamically upon collision with specific cubes, affecting movement and requiring strategic resizing.

3. **Teleportation Points**  
   - Teleport points activate after resizing the ball, allowing players to navigate through different sections.

4. **Moving Platforms**  
   - Multiple moving floors and platforms require precise timing and planning to progress.

5. **Expanded Package Support**  
   - The repository includes a variety of Unity packages to support enhanced features, assets, and scripts.

6. **Seamless Scene Transitions**  
   - Transitions between scenes (levels) are smooth, using the `LevelLoader.cs` script to handle each level’s progression.

7. **Audio Integration**  
   - Integrated sound effects provide feedback for various actions, including resizing and teleportation.

## Setup and Installation

1. **Clone the Repository**:  
   ```bash
   git clone https://github.com/jyeshtha1799/3DUnityGame-Wood-You-Roll.git


2. **Open the Project in Unity**:
   - Ensure you have Unity Hub installed.
   - Use Unity Hub to open the project with Unity version **2020.3.25f1** or newer.

3. **Run the Game**:
   - Navigate to the `Scenes` folder and load `MainScene.unity`.
   - Click `Play` to begin!

## Gameplay Instructions

- **Movement**: Use `WASD` or arrow keys to navigate the ball.
- **Camera Control**: The camera dynamically follows the ball.
- **Objective**: Resize the ball, use teleportation points, and navigate through moving platforms to reach the exit.

## Project Structure

The project is organized into the following main folders:

- **`Assets`**: Contains scripts (`BallMovement.cs`, `ResizeBallScript.cs`, `Teleport.cs`, `MovingFloor.cs`, etc.), textures, and scenes.
- **`Packages`**: Includes necessary Unity packages for project support.
- **`ProjectSettings`**: Configuration settings for project management.
- **`Scenes`**: Contains multiple levels and scene-specific settings.

## Key Scripts Overview

1. **`BallMovement.cs`**: Manages ball movement and player input.
2. **`ResizeBallScript.cs`**: Controls ball resizing based on interactions.
3. **`LevelLoader.cs`**: Manages scene transitions and level loading.
4. **`Teleport.cs`**: Implements teleportation mechanics for size-based challenges.
5. **`MovingFloor.cs`**: Controls movement and interactions of dynamic platforms.
6. **`BallSound.cs`**: Adds context-sensitive sound effects.
7. **`ExitLevel.cs`**: Manages level completion and scene transitions.

## Gameplay Video

Check out the [YouTube preview of Wood-You-Roll](https://youtu.be/GqLozbIx6IM) to see the game in action!

## Contributing

Contributions, issues, and feature requests are welcome! Check the [issues page](https://github.com/jyeshtha1799/3DUnityGame-Wood-You-Roll/issues) to get started.

1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/awesome-feature`).
3. Commit your changes (`git commit -m 'Add awesome feature'`).
4. Push to the branch (`git push origin feature/awesome-feature`).
5. Create a new Pull Request.
