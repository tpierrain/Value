# Value

A zero-dependancy pico library (or code snippets shed) to support your implementation of Value Types in your C# projects.

![Value](https://github.com/tpierrain/Value/blob/master/Value-small.jpg?raw=true)

## Value Types?
"*Value Type* (instance)" is an alternative name for DDD's *Value Objects* (VO) since VO is an oxymoron (indeed, an object has a changing state by nature). 

__A Value Type is:__
 - __immutable__ (every field must be read-only after the Value Type instantiation; no 'setter' is allowed)
 - __rich with domain logic__, relying on functions and closure of operations whenever possible
 - __Equal and Unique depending on ALL its attributes__
 - __Auto-validating__ (i.e. transactional constructor)

 As a consequence, __Value Types helps to reduce side-effects within our OO base code__.


## How "Value" can help us?

E.g.: 

 - __ValueType<T>__: making all your Value Types deriving from this base class will avoid you to forget to properly implement Equality (IEquatable) and Unicity (GetHashCode()) on ALL your fields. Very Handy!
 - __ListByValue<T>__: a list with equality based on its content and not on references (i.e.: 2 different instances containing the same items will be equals).
 - ...

 
 