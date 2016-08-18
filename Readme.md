# Value

is a zero-dependancy pico library (or code snippets shed) to help you to __easily implement Value Types__ in your C# projects without polluting your domain logic with boiler-plate code.

![Value](https://github.com/tpierrain/Value/blob/master/Value-small.jpg?raw=true)

## Value Types?
__Domain Driven Design (DDD)__'s *Value Object* being an oxymoron (indeed, an object has a changing state by nature), we now rather use the "*Value Type*" (instance) terminology. But the concept is the same as described within Eric Evan's Blue book.

__A Value Type is:__
 - __immutable__ (every field must be read-only after the Value Type instantiation; no 'setter' is allowed)
 - __rich with domain logic and behaviours__. The idea is to swallow (and encapsulate) most of our business complexity within those classes
 - __100% Ubiquitous Language__: Cure to primitive obsession, the usage of Value Types is an opportunity for us to embrace the language of our business within our code base
 - __function-oriented__ Our domain logic will be implemented by exposing, using and combining functions (following closure of operations whenever possible)
 - __providing Equality and Uniqueness based on ALL its attributes__
 - __auto-validating__ (i.e. transactional constructors with business validation inside)

As a consequence, __Value Types helps us to reduce side-effects within our OO base code__. A simple tool, for great benefits.

## Side effects, you said?

Yes, one of the problem we face when we code with Object Oriented (OO) languages like C# or java is the presence of __side-effects__. Indead, the ability for object instances to have their own state changed by other threads or by a specific combination of previous method calls (temporal coupling) __makes our reasoning harder__. Doing Test Driven Development helps a lot, but is not enough to ease the reasoning about our code.

Being inspired by functional programming (FP) languages, __DDD suggests us to make our OO design more FP oriented in order to reduce those painful side-effects__. They are many things we can do for it. E.g.: 
 - to use and combine __functions__ instead of methods that impact object states
 - to embrace __CQS pattern__ (i.e. a paradigm where read methods never change state and write methods never return data)
 - to implement *Closure of Operations* whenever it's possible (to reduce coupling with other types)
 - to use __*Value Types*__ by default and to keep *Entity* objects only when needed. An *Entity* is a object that has a changeable state (often made by combining Value Objects) for which we care about its identity.

Since there is no first-class citizen for immutability and *Value Types* in C#, the goal of this pico library is to help you easily implement Value Types without caring too much on the boiler-plate code. 

__Yeah, let's focus on our business value now!__

--- 

## What's inside the box?

E.g.: 

 - __ValueType<T>__: making all your Value Types deriving from this base class will avoid you to forget to properly implement Equality (IEquatable) and Unicity (GetHashCode()) on ALL your fields. Very Handy!
 - __ListByValue<T>__: a list with equality based on its content and not on references (i.e.: 2 different instances containing the same items will be equals).
 - ...

 
 
