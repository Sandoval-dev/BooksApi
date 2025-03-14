# Books API

## English

### Overview
Books API is a RESTful API developed using .NET for managing book records. It allows users to create, retrieve, update, and delete book entries in a structured and efficient manner.

### Features
- Create, read, update, and delete (CRUD) book records
- Create, read, update and delete (CRUD) users
- Rent a book to the user
- RESTful API architecture

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/Sandoval-dev/BooksApi.git
   ```
2. Navigate to the project directory:
   ```sh
   cd BooksApi
   ```
3. Install dependencies:
   ```sh
   dotnet restore
   ```
4. Set up the database:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run
   ```
6. Access the API via `http://localhost:5000/api/books`

### Technologies Used
- .NET Core
- Entity Framework Core
- SQL Server

### License
This project is licensed under the MIT License.

---

## Türkçe

### Genel Bakış
Books API, kitap kayıtlarını yönetmek için .NET kullanılarak geliştirilmiş bir RESTful API'dir. Kullanıcıların kitap kayıtları oluşturmasını, almasını, güncellemesini ve silmesini sağlar.

### Özellikler
- Kitap kayıtlarını oluşturma, okuma, güncelleme ve silme (CRUD işlemleri)
- Kullanıcıya kitap kiralama işlemi
- Kullanıcı oluşturma silme güncelleme işlemi
- RESTful API mimarisi

### Kurulum
1. Depoyu klonlayın:
   ```sh
   git clone https://github.com/Sandoval-dev/BooksApi.git
   ```
2. Proje dizinine gidin:
   ```sh
   cd BooksApi
   ```
3. Bağımlılıkları yükleyin:
   ```sh
   dotnet restore
   ```
4. Veritabanını yapılandırın:
   ```sh
   dotnet ef database update
   ```
5. Uygulamayı çalıştırın:
   ```sh
   dotnet run
   ```
6. API'ye `http://localhost:5000/api/books` adresinden erişebilirsiniz.

### Kullanılan Teknolojiler
- .NET Core
- Entity Framework Core
- SQL Server

### Lisans
Bu proje MIT Lisansı altında lisanslanmıştır.
