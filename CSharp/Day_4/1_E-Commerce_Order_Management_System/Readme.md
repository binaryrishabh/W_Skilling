Scenario 1: E-Commerce Order Management System
User Story

As a backend developer, I want to manage customer orders efficiently so that I can process, track, and optimize order workflows in an online store.
Problem Statement

Design a system to handle customer orders using appropriate collection types.
Requirements

    Use List<Order> to store all orders placed

    Use Dictionary<int, Customer> to map customer ID to customer details

    Use HashSet<string> to store unique product categories

    Use Queue<Order> for order processing (FIFO)

    Use Stack<string> to track order status history (LIFO)

Expected Outcome

    Add, update, and remove orders

    Process orders in sequence

    Track order status changes

    Ensure unique product categories