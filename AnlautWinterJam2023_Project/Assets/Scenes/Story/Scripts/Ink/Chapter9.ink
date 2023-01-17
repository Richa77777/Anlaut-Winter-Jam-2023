EXTERNAL image(idImage)
EXTERNAL sound(idSound)
EXTERNAL name(actorName)
EXTERNAL next(nextScene)

{image(0)}
* [Идти налево]
-> continue

* [Идти направо]
-> continue

=== continue ===
...
 
* [Идти налево]
-> continue2

* [Идти направо]
-> continue2

=== continue2 ===
...
 
* [Идти налево]
-> continue3

* [Идти направо]
-> continue3

=== continue3 ===
...
 
* [Идти налево]
-> continue4

* [Идти направо]
-> continue4

=== continue4 ===
...
 
* [Идти налево]
-> continue5

* [Идти направо]
-> continue5

=== continue5 ===
...
Я спрятался.
Цуми, пожалуйста, не надо искать меня.
Мне страшно. Очень страшно.
{next("Level10")}

-> END

-> END

-> END

-> END
-> END