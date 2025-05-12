
# RESTful Web API Wrapper (.NET 8)

This project is a simple RESTful Web API built with **.NET 8**, which wraps and extends the functionality of the mock API at [https://restful-api.dev](https://restful-api.dev). The API supports retrieving, adding, and deleting products, with enhanced features like filtering, pagination, validation, and error handling.

---

## ✅ Features

- Retrieve products from the external API with:
  - Name-based filtering (substring)
  - Pagination support
- Add new products via the API
- Delete products by ID
- Proper model validation
- Robust error handling
- Swagger UI for easy testing

---

## 🛠️ Technologies Used

- ASP.NET Core 8.0 Web API
- HttpClient
- Swagger / Swashbuckle
- System.Text.Json
- Visual Studio / VS Code

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Postman (optional)](https://www.postman.com/downloads/)

### Clone the Repo

```bash
git clone https://github.com/yourusername/RestfulApiWrapper.git
cd RestfulApiWrapper
```

### Setup

1. Open the project in Visual Studio or VS Code.
2. Update the `appsettings.json` if needed:

```json
{
  "RestfulApi": {
    "BaseUrl": "https://api.restful-api.dev/objects"
  }
}
```

3. Run the API:

```bash
dotnet run
```

By default, it will be available at: `https://localhost:5001` or `http://localhost:5000`.

---

## 📘 API Endpoints

| Method | Endpoint              | Description                         |
|--------|-----------------------|-------------------------------------|
| GET    | `/api/product`        | Get all products (supports filters) |
| POST   | `/api/product`        | Add a new product                   |
| DELETE | `/api/product/{id}`   | Delete product by ID                |

### Query Parameters for GET `/api/products`

- `name` – Filter by substring in name
- `page` – Page number (default: 1)
- `pageSize` – Items per page (default: 10)

---

## 🔎 Swagger UI

Swagger is enabled at:

```
https://localhost:{port}/swagger
```

Use it to explore and test endpoints interactively.

---

## 🧪 Example Payload

### Create Product (POST `/api/products`)

```json
{
  "name": "Apple MacBook Pro 16",
  "data": {
    "year": 2019,
    "price": 1849.99,
    "CPU model": "Intel Core i9",
    "Hard disk size": "1 TB"
  }
}
```

---

## ❗ Error Handling

- All errors return proper status codes and messages.
- Invalid input returns `400 Bad Request` with validation details.
- Deletion of a non-existing product returns `404 Not Found`.

---

## 📂 Project Structure

```
Common
/Configurations
  RestfulApiOptions.cs

Domain
/Dto
  ProductCreateDto.cs
/Interfaces
  /Repository
	IProductRepository.cs
  /Services
	IProductService.cs
/Models
  /Responses
	DeleteResponse.cs
	ProductResponse.cs
  Product.cs
/Repository
  /Product
	ProductRepository.cs
/Services
  /Product
	ProductService.cs

RESTful_API
/Controllers
  ProductController.cs
appsettings.json
Program.cs
```

---

## 📄 License

MIT License. Feel free to use, modify, and share.

---

## 🙋‍♂️ Author

**Ethern Myth**  
[GitHub](https://github.com/Ethern-Myth)
