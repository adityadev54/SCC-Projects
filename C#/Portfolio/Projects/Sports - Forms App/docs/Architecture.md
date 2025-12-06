# SPORTS APPLICATION ARCHITECTURE DOCUMENTATION

## 1. Overview
The Sports Application is a C# Windows application designed to provide an interactive experience for managing and viewing sports-related content. This documentation outlines the specific architecture and flow for the Soccer module, F1 module, and Rugby module.

## 2. Application Flow
The application follows this navigation flow:
- **SplashView** -> Initializes the application and checks authentication state.
- **AuthViews** -> Handles user authentication (Login, Register, Logout).
- **SportSelectionView** -> Allows users to choose a sport (F1, Rugby, Soccer).
- **SoccerSportView** -> Displays soccer-specific content, including teams, matches, and stats.
- **RugbyView** -> Displays rugby-related content and statistics.
- **F1View** -> Displays Formula 1 race details, teams, and stats.

## 3. Folder Structure
```
- classes/           # Utility classes and core logic
- data/              # Data sources and repositories
- docs/              # Documentation and reference files
- SportsServices/    # Services related to fetching and managing sports data
- UI/                # Windows Forms UI components and Views
```

## 4. Key Components
### a. Sports Services Layer
- Handles business logic and data processing, including:
  - Data caching mechanisms.
  - Event handling.

### b. Auth Service Layer
- Handles authentication logic, including:
	- Change password logic

## 5. Data Flow
1. User opens the application -> **SplashView** initializes and checks authentication status.
2. Authentication check:
   - **Yes** → Redirect to **SportsSelectionView**.
   - **No** → Navigate to **AuthViews**.
3. User selects a sport → Navigates to the chosen **SportView** with relevant data.
4. User explores details → Navigates to respective **Detail Views** for more information.