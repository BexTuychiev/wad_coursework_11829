This application was developed for the Web Applications Development (5COSC017C) module, as semester 1 coursework portfolio project @WIUT by student ID: 11829. 

As per the assesment criteria document, here is the calculation that determines the topic of my application:

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

```
Movies App
```
