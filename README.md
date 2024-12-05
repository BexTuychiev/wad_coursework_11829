This application was developed for the Web Applications Development (5COSC017C) module, as semester 1 coursework portfolio project @WIUT by student ID: 11829. Please, read the end of this document to find out how to run the project on your machine.

As per the assessment criteria document, here is the calculation that determines the topic of my application:

```python
student_id = 11829
remainder = student_id % 20

topic_dict = {
    0: "Task Tracker",
    1: "Expense Manager",
    2: "Simple Blog",
    3: "Newspapers App",
    4: "Book Catalog",
    5: "Events Manager",
    6: "Reception System app",
    7: "Recipe Book",
    8: "Contact Manager",
    9: "Movies App",
    10: "Spare Parts Inventory",
    11: "Fitness Tracker",
    12: "Key Store Application",
    13: "Job Board",
    14: "Survey Form",
    15: "Car Rental System",
    16: "Real Estate Listing",
    17: "Issue Tracker",
    18: "Student Grade Tracker",
    19: "Feedback System",
}

print(topic_dict[remainder])
```

Output:

```python
Movies App
```

## Instructions to run the program

1. Download and install node.js
2. Verify installation with `node --version` and `npm --version` commands
3. Install Angular CLI
4. Download and install .NET
5. Verify installation with dotnet --version
6. Clone the repo:

```bash
git clone https://github.com/BexTuychiev/wad_coursework_11829.git
cd wad_coursework_11829
```

6. Install the dependencies:

```bash
dotnet restore
```

7. Apply migrations:

```bash
dotnet ef database update
```

If you need a new migration:

```bash
dotnet ef migrations add InitialCreate
```

8. Run the application:

```bash
dotnet run
```

The API will be available at <https://localhost:5001> or <http://localhost:5000>.