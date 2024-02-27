# LondonStock 

* Project Structure is mostly there most Functional Requirements working . Project is Currently Incomplete


# Api 

#### Description

handles the user interactions and fetches data to the user interface.

## Contents:

* Api Controllers
    * Client facing Api endpoints

* Configuration 
    * Configuration of the application

* Dockerfile
    * For Containerising the Application
      
* Entry point for dependencey injection and third party services

* Nswag Client automatic Generation for generating api clients 

#### API Calls


*[ expose the current value of a stock ]* =>  **Get(string)**

*[ expose values for all the stocks on the market ]* => **GetAll()**
 
*[ expose values for a range of them (as a list of ticker symbols) ]* => **GetList(string[])**	 

 *[ receive every exchange of shares happening in real-time ]*
 * What stock has been exchanged (using the ticker symbol)
 * At what price (in pound)
 * Number of shares (can be a decimal number)
 * ID of broker managing the trade 


 => **PostTransaction([FromBody] TransationTypeDto)**

 TransactionTypeDto

```
 {
    "BrokerId" : ASHDUYIBASDUYHFBAISANMODJKNAU,
    "Ticker"   : "AMZ"
    "Price"    : "124.40
    "Volume"   : 200.0
 }
```

# Application 

#### Description

 Contains the use cases of the application and we expose the core business rules of the domain layer through the application layer

## Contents:

* #### Contracts 
    * Interfaces define Application behaviors 
* #### DTOs
    * Encapsulate data for transfer
* #### Exceptions
    * Define Custom Exceptions 
* #### Features 
    * Commands
        * Represents CREATE , UPDATE , DELETE Requests and Handlers 
    * Queries 
        * Represents Read operations Requests and Handlers 

* #### Profiles

    * Automapper mapping profiles for domain objects and DTO objects

# Domain

#### Description

* Contains the Core Domain Logic, Entities

# Persistance/Infrastructure

#### Description

*  Layer that interacts with external resources and has dependency on the application layer    (databases)

# Application Deployment 

 ## Docker

 a Dockerfile defined in Api is used to build the application and deploy it as a container 
(minimal configuration)

 ## Docker Compose

 Docker compose is used to deploy the LondonStock Api Container , Postgresql and Redis Cache 

 (minimal configuration)

 # Enchancements 

 ## How can it cope with high traffic and is it Scalable?

 ### Currently

* ### Async

    Asynchronous programming to avoid blocking threads during I/O-bound operations
    allows the application to handle more concurrent requests efficiently.

* ### In Memory Caching (*)
    Implement caching to store frequently accessed data in memory. This reduces the need for repeated expensive computations or database queries.

 ### Enchancement

 *  ### Distributed Caching(*)
    Distributed caching for resiliance and uptime access of frequently accessed data

 * ### Kubernetes Cluster

    Deploying as part of a kubernetes cluster especially as part of a cloud deployment will allow for greater scaling to cope with higher traffic 
    
*  ### Load Balancing:
    Distribute incoming requests across multiple server instances using a load balancer.

*  ### Database
    Use Connection pools

    Backup and Restore (Auditing)

*  ### Observability 

    Deploying an Observability and Monitoring Solution alongside the application 

* ### Performance Testing and Simulations 
    If Resource limited Performance test and Simulate edge case scenarios . How much Traffic at this resource level can it handle ? 

    Develop Throttling and Rate Limiting policies around this.

 # Can you Identify any bottlenecks ?

 The main bottle neck at the application level is the Mediatr.
 It is a single point of faliure and is not suitable to high traffic APIs 
 For the High Traffic and Scalability i would look to Somthing like Apache Kafka 





