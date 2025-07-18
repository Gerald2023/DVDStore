# DVDStore

<img width="1900" height="804" alt="image" src="https://github.com/user-attachments/assets/c81d5e10-493b-429c-b8b1-17f27aa34c70" />

erDiagram
    tblUser {
        INT Id PK
        VARCHAR FirstName
        VARCHAR LastName
        VARCHAR UserName
        VARCHAR Password
    }
    tblCustomer {
        INT Id PK
        VARCHAR FirstName
        VARCHAR LastName
        VARCHAR Address
        VARCHAR City
        VARCHAR State
        VARCHAR ZIP
        VARCHAR Phone
        INT UserId FK
    }
    tblMovie {
        INT Id PK
        VARCHAR Title
        VARCHAR Description
        FLOAT Cost
        INT RatingId FK
        INT FormatId FK
        INT DirectorId FK
        INT InStkQty
        VARCHAR ImagePath
    }
    tblOrder {
        INT Id PK
        INT CustomerId FK
        DATETIME OrderDate
        INT UserId FK
        DATETIME ShipDate
    }
    tblOrderItem {
        INT Id PK
        INT OrderId FK
        INT MovieId FK
        INT Quantity
        FLOAT Cost
    }
    tblDirector {
        INT Id PK
        VARCHAR FirstName
        VARCHAR LastName
    }
    tblGenre {
        INT Id PK
        VARCHAR Description
    }
    tblMovieGenre {
        INT Id PK
        INT MovieId FK
        INT GenreId FK
    }
    tblFormat {
        INT Id PK
        VARCHAR Description
    }
    tblRating {
        INT Id PK
        VARCHAR Description
    }
    
    tblCustomer ||--o{ tblOrder : "places"
    tblUser ||--o{ tblCustomer : "has"
    tblUser ||--o{ tblOrder : "processes"
    tblOrder ||--|{ tblOrderItem : "contains"
    tblMovie ||--|{ tblOrderItem : "ordered in"
    tblMovie ||--o{ tblMovieGenre : "categorized as"
    tblGenre ||--o{ tblMovieGenre : "categorizes"
    tblMovie ||--|| tblDirector : "directed by"
    tblMovie ||--|| tblFormat : "in format"
    tblMovie ||--|| tblRating : "rated as"
