# SPORTS APPLICATION ARCHITECTURE DOCUMENTATION

## 1. Overview
The Sports Application is a C# Windows application designed to provide an interactive experience for managing and viewing sports-related content. This documentation outlines the specific architecture and flow for the Soccer module, F1 module, and Rugby module.

---

## 2. Application Flow
The application follows this navigation flow:
- **SplashView** → Initializes the application and checks auth state.
- **AuthView** → Handles user authentication (Login, Register, Logout).
- **SportSelectionView** → Allows users to choose a sport (F1, Rugby, Soccer).
- **SoccerSportView** → Displays soccer-specific content, including teams, matches, and stats.
- **RugbyView** → Displays rugby-related content.
- **F1View** → Displays F1 race schedules, stats, and team performance.

---

## 3. Folder Structure
```
- classes/             # Utility classes and core logic
- data/                # Data sources and repositories
- docs/                # Documentation and reference files
- SportsServices/      # Services related to fetching and managing sports data
- UI/                  # Windows Forms UI components and Views
```

---

## 4. Key Components
### a. Sports Services Layer
The Sports Services layer handles business logic and data processing, including:
- Data caching mechanisms.
- Event handling.

---

## 5. Data Flow
1. User opens the application → **SplashView** initializes and checks auth status.
2. **Authenticated?**
   - **Yes** → Redirect to **SportSelectionView**.
   - **No** → Navigate to **AuthView**.
3. User selects a sport → Navigates to its chosen **sport view** with relevant data.
4. User explores details → Navigates to its **details views** for more information.

---

# MULTI-FILE-DATA-SERVICE & DATA HANDLING

## Overview
The Multi-File-Data-Service is responsible for handling sports data from multiple CSV files, processing them into a structured `DataTable`, and ensuring efficient filtering and searching.

### How It Works:
1. Accepts multiple CSV file URLs categorized by season.
2. Fetches and caches CSV data for performance.
3. Parses CSV content dynamically, ensuring unique column names.
4. Merges data into a unified `DataTable` with a **Season** column.
5. Supports searching, filtering, and extracting unique values from columns.

### Key Functions:
- `LoadDataAsync()` → Fetches and processes CSV data.
- `GetAllData()` → Retrieves the combined dataset.
- `SearchData()` → Performs keyword-based search across specified columns.
- `FilterDataByColumn()` → Filters data based on a specific column and value.
- `GetUniqueColumnValue()` → Extracts distinct values from a column.

# TEAM PERFORMANCE ANALYSIS SERVICE

## Overview
The Team-Perf-Analysis-Service is responsible for analyzing and providing predictions based from the sports data.

### How It Works:
1. The service receives a `DataTable` containing historical match data.
2. Then it calculates performance metrics (wins, losses, draws, win rate) for a specified team from the data.
3. And to predict matches, it retrieves the number of wins for each team from the data.
4. Then it compares the win counts of the two teams to predict which team is more likely to win or if it will be a draw.
5. Lastly, the service returns the calculated team performance statistics and the match prediction result.

### Key Functions:
- `GetTeamPerfStats()` → Calculates and returns performance statistics for a given team.
- `PredictMatchOutcome()` → Predicts the outcome of a match between two teams.
- `GetTeamWins()` → Retrieves the number of wins for a given team.

---

## My Continuous Efforts to Keep the Main + Helper Services Updated and Efficient working

| Date       | Update / Fix Done             | Short Description                                  |
|------------|-------------------------------|----------------------------------------------------|
| 02/17/25   | Initial Setup (Work Mode)     | Created the initial setup                          |
| 02/24/25   | Optimized CSV Processing      | Improved CSV parsing with CsvHelper config         |
| 02/28/25   | Implemented ETag Caching      | Prevented unnecessary CSV re-fetching              |
| 02/28/25   | Fixed Header Duplication      | Ensured unique column names                        |
| 02/28/25   | Enabled Large File Handling   | Used `IDataReader` for streaming large CSV files   |
| 03/02/25   | Improved Thread Safety        | Used `ConcurrentBag<DataRow>` for batch processing |
| 03/02/25   | Enhanced Logging System       | Stored errors in log files instead of `MessageBox` |
| 03/02/25   | Fixed Column Count Mismatch   | Ensured data aligns with `_combinedDataTable`      |
| 03/04/25   | Improved UI Responsiveness    | Replaced `MessageBox.Show()` with async UI updates |
| 03/04/25	 | Minor Improved performance	 | Avoided multiple enumerations					  |
| 03/04/25	 | Comment Updates				 | Updated my comments for better understanding		  |
| 03/04/25   | Empty Result Handling		 | Early exit for empty matches						  |
| 03/04/25   | Code Optimization			 | Cleaned code structure							  |
| 03/06/25	 | New Auth Service Created		 | Handles User register, login, and Password Retrive |
| 03/08/25	 | Updated the Auth Service		 | Added feedbacks through code + Minor Comments	  |
| 03/10/25	 | Quick Look					 | Quick check and Minor fixes						  |

**Note:** To view necessary updates, I have commented `// Updated: ...` in the source code.

---

## Resources
### a. Useful Libraries & Resources for Group Project #1:
- **CsvHelper** → For handling CSV parsing efficiently.  
  [CsvHelper Examples](https://joshclose.github.io/CsvHelper/examples/)
- **HttpClient** → For making HTTP requests asynchronously.  
  [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-9.0)  
  _Reference: "C# 10 and .NET 6 Modern" PDF_
- **Windows Forms** → Used MS documentation for building UIs.  
  [UI Principles](https://learn.microsoft.com/en-us/windows/win32/appuistart/-user-interface-principles)  
  [Design Guidelines](https://learn.microsoft.com/en-us/windows/apps/design/)
- **Concurrent Collections** → For thread-safe data handling.  
  [Thread-Safe Collections](https://learn.microsoft.com/en-us/dotnet/standard/collections/thread-safe/)
- **Debugging and Logging** → Better debugging process.  
  [Serilog](https://serilog.net/)
- **Async Programming** → Managing parallel tasks.  
  [Async Scenarios](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios)  
  [Task Parallel Library](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl)  
  _Reference: "C# 10 and .NET 6 Modern" PDF_
- **IDataReader** → Fast, forward-only data handling for large datasets.  
  [IDataReader Docs](https://learn.microsoft.com/en-us/dotnet/api/system.data.idatareader?view=net-9.0)

### b. Online Data Sources:
- **Football Datasets:** [GitHub Repo](https://github.com/datasets/football-datasets/tree/main)  
  _Provides live score data and historical records for integration into the sports application._

---

# DATA MANAGEMENT FOR OTHER SPORTS

## Rugby
*To be documented by Adam...*

---

## F1 (Formula 1)
*To be documented by Katherine...*

---

