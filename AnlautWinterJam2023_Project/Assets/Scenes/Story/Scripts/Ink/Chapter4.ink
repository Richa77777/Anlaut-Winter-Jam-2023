EXTERNAL image(idImage)
EXTERNAL soundOn(soundName)
EXTERNAL soundOff()
EXTERNAL name(actorName)
EXTERNAL next(nextScene)
EXTERNAL updateBar(barValue)

{soundOn("happy")}
{updateBar(0.75)}
{image(0)}
{name("Цуми")}
“Ого, вот это костюм! Спасибо, друг!”
{name("Ты")}
“Пожалуйста...”
Это стоило мне тысячи иен, а я для тебя всё ещё “друг”.
Неблагодарная.

{soundOff()}
{image(1)}
{name("Цуми")}
“Что ты сказал?”
...
{name("Ты")}
“Н-ничего.”
...
Что это было?
Наверное, просто запрограммированная реплика.

{name("Ты")}
“Ах-ах, Цуми, не пугай меня так больше!”
Сейчас я схожу в душ и-

{image(2)}
{name("Цуми")}
“Пойдём играть!”
Пойдёшь играть?

 
* [Да]
Пошли, моё золотце. Только заработаю монетку...
-> continue

* [Нет]
Не... Ну уж нет, я не могу отказаться!
Пошли, моё золотце. Только заработаю монетку...
-> continue

=== continue ===
 
* [“Цуми, ты нужна мне.”]
{next("Level5")}
-> END