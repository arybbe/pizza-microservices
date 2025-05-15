# Pizza MicroServices

Två små .NET 8-mikrotjänster (MenuService & OrderService) + SQL Server 2022, körda containeriserat via Docker Compose.

## 📋 Förkrav

- **Docker Desktop** ≥ 4.x  
- (Valfritt) **.NET SDK 8.0** om du vill köra lokalt utan Docker  

## 🚀 Kom igång

1. Klona repot  

   git clone https://github.com/arybbe/pizza-microservices.git
   cd pizza-microservices

2. Bygg & starta alla tjänster

    docker compose up --build   # första gången
    docker compose up -d        # kör i bakgrunden vid omstart

3. Stäng av & ta bort volymer

    docker compose down -v

| Tjänst           | URL                                                            | Beskrivning                       |
| ---------------- | -------------------------------------------------------------- | --------------------------------- |
| **MenuService**  | [http://localhost:5001/swagger](http://localhost:5001/swagger) | CRUD på pizzamenyn                |
| **OrderService** | [http://localhost:5002/swagger](http://localhost:5002/swagger) | Skapa & hämta orders              |
| **SQL Server**   | localhost:1433 (sa / Your\_password123!)                       | Utvecklings-DB (volym `sql_data`) |
