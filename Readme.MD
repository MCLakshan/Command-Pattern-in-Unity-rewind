# Unity Command Pattern Example - Player Movement and Action Recording

This Unity project demonstrates the use of the **Command Pattern** to handle player movement actions as discrete, reusable commands. This approach allows for enhanced features like undoing actions, recording and rewinding action sequences, and easily extending functionality.

## Overview

The Command Pattern is implemented here to manage player actions (like moving in different directions) as commands that can be recorded, executed, and undone. This setup is especially useful for game features that require complex action tracking, such as rewinding, replaying, or chaining commands.

### Project Structure

The project consists of the following core scripts:

1. **Unit.cs** - Manages movement behavior of the player or unit.
2. **PlayerController.cs** - Detects player input and issues movement commands.
3. **ActionRecorder.cs** - Records and manages the execution of actions.
4. **Direction.cs** - Defines direction vectors for movement.
5. **ActionBase.cs** and Derived Classes - Define the structure and implementation of each specific command.

## Key Components

### 1. `ActionBase` - Command Encapsulation

`ActionBase` is the base class for all commands, defining the methods `Execute()` and `Undo()`. These methods create a clear contract for each command, making it easy to add new commands while maintaining consistent functionality.

**Key Points:**
- `ActionBase` is an abstract class with the `Execute` and `Undo` methods.
- Each specific command (e.g., `MoveFrontAction`, `MoveBackAction`) inherits from `ActionBase` and implements these methods for specific movement behaviors.

### 2. Concrete Commands - `MoveFrontAction`, `MoveBackAction`, etc.

Each concrete command, like `MoveFrontAction` or `MoveBackAction`, is a subclass of `ActionBase` and represents a specific player action. Each command has:
- An `Execute()` method that moves the player in the specified direction.
- An `Undo()` method that reverses the action, allowing for rewinding functionality.

These commands follow the **single-responsibility principle**, handling only one specific action, which makes the code easy to extend with new commands.

### 3. `ActionRecorder` - Invoker Class

`ActionRecorder` is the **invoker** of commands. It’s responsible for:
- Executing commands by calling `Execute()` on each command.
- Recording commands by pushing them onto a stack.
- Rewinding actions in reverse order by calling `Undo()` on the most recent command in the stack.

**How it Works:**
- `ActionRecorder.Record()` takes a command, executes it, and records it for potential undoing later.
- `ActionRecorder.Rewind()` undoes the last recorded command if available, enabling the rewind feature.

### 4. `PlayerController` - Input Handler

The `PlayerController` class handles player input and creates commands based on the detected input. It doesn’t execute commands directly but instead:
1. Creates a command instance (like `MoveFrontAction`) based on the input.
2. Passes this command to `ActionRecorder`, which manages the execution and recording.

This decoupling makes it easy to change input handling or add new commands without modifying the movement logic itself.

### 5. `Unit` - Movement and Coroutine Management

The `Unit` class contains the actual movement logic for the player or unit. It provides methods like `MoveFront`, `MoveBack`, etc., which adjust the unit’s position based on direction vectors defined in the `Direction` class.

- **Smooth Movement:** The `MoveCoroutine()` method gradually moves the unit towards the target position, allowing for smooth movement over time.
- **Direction Management:** Uses predefined vectors from the `Direction` class to determine movement direction.

## How the Code Works

1. **Input Detection (in `PlayerController`)**  
   When a player presses a movement key (e.g., **W**, **A**, **S**, or **D**), `PlayerController` creates the appropriate command (e.g., `MoveFrontAction` for **W**).
   
2. **Command Execution and Recording (in `ActionRecorder`)**  
   `PlayerController` passes the command to `ActionRecorder` using `Record(action)`.
   - `ActionRecorder` calls `action.Execute()` to perform the movement.
   - The command is pushed onto a stack, allowing for future rewinding.

3. **Rewind Functionality**  
   When **R** is pressed, `ActionRecorder`'s `Rewind()` method is called.
   - This method pops the most recent command from the stack and calls its `Undo()` method, reversing the action.

## Sample Code Walkthrough

Here's a quick summary of how an action (e.g., moving forward) works from start to finish:

- **Step 1**: The player presses **W**.
- **Step 2**: `PlayerController` detects the input and creates a `MoveFrontAction`.
- **Step 3**: `PlayerController` passes this command to `ActionRecorder`.
- **Step 4**: `ActionRecorder.Record()` calls `MoveFrontAction.Execute()` to move the unit forward.
- **Step 5**: The command is stored in the stack.
- **Step 6**: If **R** is pressed, `ActionRecorder.Rewind()` calls `MoveFrontAction.Undo()` to move the unit back.

## Benefits of the Command Pattern

- **Undo/Redo Support**: By structuring commands with `Execute` and `Undo`, the system supports undoing recent actions.
- **Centralized Command Management**: All actions go through `ActionRecorder`, making it easy to manage and track command history.
- **Extensibility**: Adding new commands is straightforward and doesn’t require changes to existing code, following the Open/Closed Principle.

This setup demonstrates a foundational use of the Command Pattern in Unity, providing both flexibility and scalability for game development. Enjoy exploring and building on this pattern!
