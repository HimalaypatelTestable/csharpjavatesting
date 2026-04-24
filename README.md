# csharpjavatesting

Mixed-language sample repo used for testing. Majority of code is C#, with a Java
module and a small static web page covering JavaScript, HTML and CSS.

## Layout

```
csharp/       .NET 8 console app (Program, Models, Services, Controllers, Utils)
java/         Maven/Java 17 module (Main, Calculator, StringUtils, BankAccount)
web/          Static page (index.html, styles.css, app.js)
```

## Run

### C#
```
cd csharp
dotnet run
```

### Java
```
cd java
javac -d out $(find src/main/java -name "*.java")
java -cp out com.example.Main
```

### Web
Open `web/index.html` in a browser.
