# What Has Been Asked in the Question
    # Problem Statement

        Build a console-based Order Processing System for an e-commerce platform that can:

    # Process orders

        *   Trigger multiple notifications (Email, SMS, Logging)

        *   Allow different modules to subscribe/unsubscribe dynamically

        *   Use delegates and events to decouple logic

# User Stories (5 Requirements)
    #User Story	Expected Implementation
        1   As a system, I want to process an order so that I can notify different systems when an order is placed	Create Order class (OrderId, CustomerName, Amount), OrderProcessor class, and define a delegate for order processing
        2	As a system, I want multiple services (Email, SMS, Logger) to be notified so that all stakeholders are informed	Create delegate public delegate void OrderPlacedHandler(Order order) and attach multiple methods: SendEmail(), SendSMS(), LogOrder()
        3	As a developer, I want to trigger events when an order is placed so that subscribers can react independently	Use event keyword: public event OrderPlacedHandler OnOrderPlaced
        4	As a system, I want modules to subscribe/unsubscribe dynamically so that notifications can be controlled	Create EmailService, SMSService, LoggerService classes and use += / -= operators
        5	As a system, I want event handling to be delegated to external services so that OrderProcessor remains clean and reusable	OrderProcessor only triggers the event; external services handle the actual notifications

# Constraints

    *   Use delegate + event

    *   Use multicast delegate

    *   Avoid tight coupling

    *   Console-based only

    *   No external libraries