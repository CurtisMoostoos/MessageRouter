# System Overview
An example Messaging Routing API which is a component of an overall email messaging system. A brief outline of the architecture follows. In the diagram below, the arrows indicate the direction of the calls being made.

    
![image](https://user-images.githubusercontent.com/10727539/133285891-e14c8cfe-d925-4457-8690-ce7d972579ea.png)

## Mesage Router Public APi
- This project you are viewing.
- It is the entry point to the entire system accessible to our customers via the API
- It will appy logic to determine such things as if a sender is allowed to send from a certain email address, check if customer accounts are active, check if recipients of emails have opted out, etc.

## Message Queue Broker
- This is a wrapper over the message queue functionality and would be intended to the interface for all other applications/services that need to interact with the queues.

## Natural Language Service
- Api which utilizes machine learning to classify the contents of an email to see if it violates terms of service. Hate speech for example.
- This is an area I am still pretty new to, but somehting like a naive Bayes classifer may work.

## Message Queue
- Commercial message queue softare like IBM MQ or comparable

## Email Sender
- This is what is actually sending out the emails that have passed through the validation the message router

## Email Database
- Relational database containing customer info, records of emails sent, receipient email preferences and so on. 


## Notes on Scalability and availability
It is envisioned that the components of the system will be behind a loadbalancer such as a NetScalar. To ensure high availability a minimum of 2 instances of each component is required. This will allow bringing the components down as required for things like installing updates.

Scalability is primary achieved by scaling out, that is adding additional instances of each component as they become bottle necked. Containerization is recommended as it allows this process to happen much easier and can be in an automated fashion.

The availabilty of the database is depending on the choice of database software. In Microsoft SQL Server this may be achieve with Always On Avaiability Groups. 

## Things that are missing
This is not meant to be a totally complete architecture. Details on things like DNS (really anything networking), load balancing, server configuration, and so forth, would need to be thought about and flehsed out.


# Message Router Overview
The following gives a brief overview of the projects that make up the solution and their intended purposes. The solution is architected as a domain driven REST web service.

## MessageRouter.Api
This layer provides a public interface to RESTful services implemented using .Net Core Web API. Containss controllers and everything related http response/requests and authentication of API Key.

## MessageRouter.Application
The Application Layer mediates between the API Layer and Domain Layer, and orchestrates business objects to perform specific application tasks. It provides a clean separation between the API Layer and the Domain Layer, which contributes to the clarity of the entire architecture. 
The major components in this layer are the Application Services, the DTOs, and the DTO mappers.

## MessageRouter.Domain
The Domain Layer consists of the custom exceptions (if any), Domain Models, and Repository Interfaces. Important to note that the domain models here are more than just bags of getter and setters. you should be trying to put as much of the business logic into the domain as possible.

## MessageRouter.Infrastructure
The Infrastructure Layer is anything that is related to using the concrete technologies. The primary focus in the Infrastructure Layer is the implementation of the data access components. Part of this implementation may include thing such as memcache, though that is not included in this example.
I have adopted the Repository pattern to implement various data access components in the Infrastructure Layer. 


