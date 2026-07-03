# .NET Module Submission

## GitHub Repository

https://github.com/bitfws/cse325.git

---

# 1. Create a Web API with ASP.NET Core Controllers

This project is a simple RESTful Web API built with ASP.NET Core. It manages a pizza inventory using an in memory data store.

The API supports basic CRUD operations.

---

## Endpoints

### GET /pizza

Returns all pizzas.

Status:

- 200 OK

Example response:
[
{
"id": 1,
"name": "Classic Italian",
"isGlutenFree": false
}
]

---

### GET /pizza/{id}

Returns a pizza by its ID.

Status:

- 200 OK
- 404 Not Found

Example:
{
"id": 1,
"name": "Classic Italian",
"isGlutenFree": false
}

---

### POST /pizza

Creates a new pizza.

Status:

- 201 Created

Request:
{
"name": "Pepperoni",
"isGlutenFree": false
}

Response:
{
"id": 4,
"name": "Pepperoni",
"isGlutenFree": false
}

---

### PUT /pizza/{id}

Updates an existing pizza.

Status:

- 204 No Content
- 400 Bad Request
- 404 Not Found

Request:
{
"id": 4,
"name": "Updated Pepperoni",
"isGlutenFree": false
}

---

### DELETE /pizza/{id}

Deletes a pizza.

Status:

- 204 No Content
- 404 Not Found

---

## API Testing

The API was tested using a browser, HttpRepl, and REST Client in VS Code. All endpoints return the expected responses and status codes.

---

# 2. Work with Files and Directories in .NET

This application reads sales data from JSON files in the stores directory.

It:

- Searches for JSON files in subfolders
- Reads and deserializes file content
- Calculates total sales
- Generates a summary report
- Writes output files (totals.txt and summary.txt)

---

## Example Output

## Sales Summary

store1.json: $5,000.00  
store2.json: $7,345.67

Total Sales: $12,345.67

---

# 3. Summary

This project demonstrates working with ASP.NET Core Web APIs and file handling in .NET, including JSON processing and report generation.
