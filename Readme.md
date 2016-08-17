# Value

_*Value*_ is a zero-dependancy pico library (or code snippets shed) to support your implementation of Value Types in your C# projects.


## Value Types?
"*Value Type* (instance)" is an alternative name for DDD's *Value Objects* (VO) since VO is an oxymoron (indeed, an object has a changing state by nature). 

_A Value Type is:_
 - _immutable_ (every field must be read-only after the Value Type instantiation; no 'setter' is allowed)
 - _rich with domain logic_, relying on functions and closure of operations whenever possible
 - _Equal and Unique depending on ALL its attributes_
 - _Auto-validating_ (i.e. transactional constructor)

 As a consequence, __Value Types helps to reduce side-effects within our OO base code__.


## How "Value" can help us?

E.g.: 

 - __ValueType<T>__: making all your Value Types deriving from this base class will avoid you to forget to properly implement Equality (IEquatable) and Unicity (GetHashCode()) on ALL your fields. Very Handy!
 - ...
 
 