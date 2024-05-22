# Endless Runner Game

Welcome to the Endless Runner game repository! This project showcases a well-structured and optimized endless runner game developed using Unity.

## Features

- **Modular Design with Design Patterns**
  - Applied **Dependency Injection** and **MVC** for modular and scalable player management.
  - Used the **Command Pattern** for handling player movement actions (move left, move right, jump).
  - Employed the **Observer Pattern** for efficient event handling in the event service.
  - Implemented a **State Machine** to manage player states (running, jumping, death).

- **Performance Optimization**
  - Utilized **Object Pooling** for leaderboard entities and endless ground generation to enhance performance and reduce memory usage.
  - Leveraged **Scriptable Objects** for flexible and reusable data configurations.

- **Integration with Unity Services**
  - Integrated **Unity Authenticator** for secure user login.
  - Utilized **Unity Leaderboards** for tracking and displaying player scores online.

## Demo

Check out the game in action on YouTube: [Endless Runner Game Demo](https://www.youtube.com/watch?v=6isuBRfdLfI&t=23s)

[![Endless Runner Game Demo](https://img.youtube.com/vi/6isuBRfdLfI/0.jpg)](https://www.youtube.com/watch?v=6isuBRfdLfI&t=23s)

## Design Patterns and Architecture

1. **Dependency Injection and MVC**
   - Ensures modular and scalable management of game components.
   
2. **Command Pattern**
   - Encapsulates player movement actions, making them easier to manage and extend.
   
3. **Observer Pattern**
   - Facilitates efficient and decoupled event handling.
   
4. **State Machine**
   - Manages various player states ensuring smooth transitions and logic handling.
   
5. **Object Pooling**
   - Optimizes performance by reusing objects, reducing the overhead of frequent instantiation and destruction.
   
6. **Scriptable Objects**
   - Provides a flexible and reusable way to configure game data.

## License
Distributed under the MIT License. See [LICENSE](LICENSE) for more information.
