using Delegates;

Console.WriteLine("Hello, World!");

////Why Delgates are required in C#
//1. Delegates are used to implement event handling in C#.
//They allow you to define a method that will be called when a specific event occurs, 
//such as a button click or a timer tick
// 2. Delegates are used to implement callback functions in C#.
// Where you can pass a method as a parameter to another method, and that method can call the original method when it needs to.
// 3. Delegates are used to implement 

//Since we dont have pointers in C#, delegates provide a way to reference methods and
//invoke them dynamically at runtime, which is essential for implementing the observer pattern

//Steps for getting started with delegates in C#:
//Step 1: Define a delegate type that specifies the signature of the method that the delegate will reference.
//Step 2: Create an instance of the delegate and assign it a method that matches the signature of the delegate type.
//Step 3: Invoke the delegate to call the method it references.
//Step 4: Optionally, you can use multicast delegates to reference multiple methods and invoke them at the same time

/// Question 
// Figure out real world scenerios of Function pointers it could  be 


//Problem statement based on use of delgates in C#:
//1. Create a delegate type called "MathOperation" that takes two integers as parameters and
//returns an integer as output.
//2. Implement three methods that match the signature of the "MathOperation" delegate:
//   a. Add: This method should return the sum of the two integers.
//   b. Subtract: This method should return the difference of the two integers.
//   c. Multiply: This method should return the product of the two integers.
//3. Create an instance of the "MathOperation" delegate and assign it the "Add" method.
//4. Invoke the delegate with two integers and display the result.
//5. Change the delegate assignment to the "Subtract" method and invoke it again with the same integers,
//displaying the result.

// Here is a delegte MathOperation that takes two integers and returns an integer as output.
// needs to be defined before the main method of the  class.


// Creating an instance of the MathOperation delegate and assigning it to the Add method.
MathOperation mathOperation = delegateClass.delegateOne.Add;
Console.WriteLine("Delegate ref is created and currently added is assigned to it");

// Invling the delegate with two integers and displaying the result.
int result = mathOperation(10, 5);
Console.WriteLine($"Since delegate is pointing to Add() so the result of Addition is {result}");

// Changing the delegate assignment to the Subtract method and invoking it again with the same integers,
// displaying the result.
mathOperation = delegateClass.delegateOne.Subtract;
result = mathOperation(10, 5);
Console.WriteLine($"Since delegate is pointing to Subtract() so the result of Subtraction is {result}");

// changing the delefate assignment to the Multiply method and invoking it again with the same integers,
// displaying the result.
mathOperation = delegateClass.delegateOne.Multiply;
result = mathOperation(10, 5);
Console.WriteLine($"Since delegate is pointing to Multiply() so the result of Multiplication is {result}");




//Multicasting delegate are used in following sceanrios::
//1. When you want to execute multiple methods in response to a single event, such as a button click or a timer tick.
//2. When you want to implement the observer pattern, where multiple observers need to be notified of changes in a subject.
//3. When you want to implement a publish-subscribe model, where multiple subscribers can register to receive notifications from a publisher.
//ex for publisher subsriber model can be in a sceanrio where you have a news publisher that publishes news articles, and multiple subscribers that want to receive notifications when a new article is published.
//You can use a multicast delegate to allow the publisher to notify all subscribers at once when a new article is published.

//In the above code we have created a delegate type called "MathOperation" that takes two integers as parameters and returns an integer as output.

//here we can have publish-subscriber model where MathOperation delegate can be used as a publisher and we can have multiple subscribers that want to receive notifications when a new math operation is performed.


//here we can have publish-subscriber model where MathOperation delegate can be used as a publisher and we can have multiple subscribers that want to receive notifications when a new math operation is performed.

// Step 1: Define a delegate type that specifies the signature of the method that the delegate can reference. (We have already defined the MathOperation delegate)
// Step 2: Create a class that will act as the publisher and define an event that uses the delegate type.
// (We can create a class called "MathPublisher" that has an event called "OnMathOperationPerformed" of type MathOperation)
// Step 3: Create a class that will act as the subscriber and define a method that matches the signature of the delegate. (We can create a class called "MathSubscriber" that has a method called "HandleMathOperation" that takes two integers as parameters and returns an integer as output)
// step 4: In the main method, create an instance of the publisher and subscribe the subscriber's method to the publisher's event.
// Step 5: Invoke the publisher's event to notify all subscribers when a new math operation is performed.
