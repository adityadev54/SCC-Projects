# Bit by Bit
First Impression
Upon running the program, I had some problems with the databases and table adapters, and I could not get them to work. However, this is likely an issue with it running in a different environment rather than with the app itself.

### ***SplashView Form Code***
I find the code for this form to be well-documented. I like the progress bar, though I think it would be better if the program would open a connection to the databases while it was loading.

### ***LoginView Form Code***
I find the code for this form to be well documented. One thing that I would include is trimming for the username and password in the btnLogin click event. I realized that the password visibility toggle in the chkShowPassword click event can be simplified to just the following line of code: <br/>
`txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;`

### ***PasswordResetView Form Code***
I find the code for this form to be well documented. I noticed that when methods from AuthService are used, there is not a try-catch to handle any errors with the database.

### ***RegisterView Form Code***
I find the code for this form to be well documented. As with the PasswordResetView form, this form also creates a new LoginView form instead of unhiding the existing one. One change that I would make her is to trim all the sign-up info strings before working with them. Also converting the email and username to lowercase will improve the user’s experience. I noticed that there is no validation to ensure that the user selects a security question, just that they input an answer.	

### ***SportSelectView Form Code***
I find the code for this form to be well documented. I did not see an problems with the code, except that an AuthService variable was declared but never used. 

### ***RacingView Form***
I find the code to be well documented. I do wonder why the form is not partial, separating the controls and the logic.

### ***RacingSeasons Form Code***
I find the code for this form to be well documented. I did not notice any problems with this code.

### ***RacingMoreDetails Form Code***
I find the code for this form to be well documented. I did not notice any problems with this code.

### ***RugbyView Form Code***
I find the code for this form to be well documented. One problem that I see is the exit click event will close the entire application rather than the form.

### ***SoccerView Form Code***
I find the code for this form to be well documented. I like that the data is loaded from the CSVs on GitHub, but it may be better to store the data in a table. Then, if the data in the table is lost, restore it from the CSVs

### ***F1Class, User, and UserSession code***
Because these classes are for entities, they do not need any documentation. I did not notice any problems with this code.

### ***UserDb Code***
This class is simple, so it does not need documentation. I did not notice any problems with this code.

### ***AuthService Code***
I find the code for this class to be well documented. I did not notice any problems with this code, though I would pass the username or email to the HashPassword method instead of null.

### ***MultiFileDataService Code***
 I find the code for this class to be relatively well documented, though some code, such as the lock, could use a comment to explain what it does.

### ***TeamPerfAnalysisService Code***
I find the code for this class to be well documented. I noticed that the LINQ query in GetTeamWins could be optimized slightly by using the following code:
<br/>
``` 
string homeTeam = row.Field<string>("HomeTeam");
if(team == homeTeam)
{
  int homeGoals = row["FTHG"] is DBNull ? 0 : Convert.ToInt32(row["FTHG"]);
  int awayGoals = row["FTAG"] is DBNull ? 0 : Convert.ToInt32(row["FTAG"]);
  return  homeGoals > awayGoals;
}
return false;
```

### ***Testing***
I found that when I enter just spaces in the register form, I can still sign up. I can also enter an answer to a security question without actually selecting one.
