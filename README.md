# Bài thực hành 7 – Lưu trữ dữ liệu với Marten

Repository kế thừa solution TH6. Bài thực hành 7 bổ sung code giáo viên cho `PaymentService` và `ProductService`, tập trung vào lưu trữ dữ liệu với Marten.

## Thành phần được bổ sung ở TH7

- `PaymentService`, `PaymentService.Api` và `PaymentService.Test`: quản lý thanh toán; `PaymentService` dùng Marten với PostgreSQL.
- `ProductService`, `ProductService.Api` và `ProductService.Test`: quản lý danh mục sản phẩm.
- Các service và thành phần còn lại được kế thừa từ các bài thực hành trước, gồm gateway Ocelot, Auth, Chat, Dashboard, Pricing, Eureka, Web, Blazor và PostgreSQL.

## Chạy các thành phần

Cần .NET 8 SDK và Docker Desktop. Eureka và PostgreSQL có thể khởi động từ thư mục gốc:

```powershell
docker compose up --build -d eureka-server postgres
```

Chạy API Gateway:

```powershell
dotnet run --project .\AgentPortalApiGateway\AgentPortalApiGateway
```

Gateway lắng nghe tại `http://localhost:8099`. Giao diện Eureka ở `http://localhost:8761`. Để chạy Web bằng Docker, build từ `Web` và ánh xạ cổng `8081` nếu cổng `8080` đã được dùng:

```powershell
docker build -t th7-web-ui:local .\Web
docker run --rm -p 8081:80 th7-web-ui:local
```

## Build

```powershell
dotnet build .\TH7InsuranceMicroservices.sln --nologo
```

Không chạy test tự động nếu chưa được yêu cầu; integration tests có thể cần Docker và dịch vụ phụ trợ.

## Cấu hình và dữ liệu cục bộ

Không commit `.env`, secrets, database dumps, archive RAR, hoặc output build. Cấu hình cục bộ nhạy cảm nên được truyền qua biến môi trường; giữ các tệp cấu hình và dữ liệu mẫu do giáo viên cung cấp theo quy tắc `.gitignore` hiện có.
