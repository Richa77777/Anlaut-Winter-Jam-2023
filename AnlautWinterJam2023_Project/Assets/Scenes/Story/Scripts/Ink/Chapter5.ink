EXTERNAL image(idImage)
EXTERNAL sound(idSound)
EXTERNAL name(actorName)
EXTERNAL next(nextScene)
EXTERNAL updateBar(barValue)

{updateBar(0.9)}
{image(0)}
Мы остановились с Цуми около какого-то моря.
Мне очень нравится её пляжный костюм.
В нём она особенная милая.
И как будто более настоящая.
Не зря потратил полдня на то, чтобы его получить.


{image(1)}
{name("Цуми")}
“Ах, как на улице жарко! Вот бы кто-нибудь помог мне охладиться...”
Бедная, наверное, весь день ничего не пила...
А, может, даже дольше.
Срочно, вода для Цуми!
Наверняка в моём инвентаре есть что-то, что ей поможет.

 
* [*Взять воду*]
-> continue

=== continue ===
{image(2)}
{name("Цуми")}
“Точно, я же взяла свою бутылочку с собой!”
Какого..?
Блин, такой шанс повысить дружбу упустил!
Цуми, я столько делаю ради того, чтобы мы с тобой стали парой…
Но, кажется, ты этого просто не хочешь.

{image(3)}
{name("Цуми")}
“А ты не хочешь попить? Держи водичку!”
{name("Цуми")}
“А то ты, наверное, целый день ничего не пил!”

 
* [“Хочу, давай!”]
-> continue2

=== continue2 ===
{image(4)}
{name("Цуми")}
“О, смотри, мои подруги!”
Аргх! Что за фигня?!
Я посмотрел в левую часть экрана.
Откуда ни возьмись появились её эти подружки.
Буквально секунду назад там ничего не было!

{name("Ты")}
“Нет, Цуми, мы останемся здесь!”
...
Не услышала.
Ну конечно, я же сказал это вслух.

{image(5)}
{name("Цуми")}
“Постоишь здесь, пока я общаюсь с ними?”
Будто у меня есть выбор.

 
* [“Да, постою.”]
-> continue3

=== continue3 ===
{image(6)}
Я не собираюсь терпеть эту получасовую кат-сцену с её подружками.
Поэтому просто перезайду.
В моих руках столько власти в этой игре!
Я могу привлечь к себе любую тян, у меня достаточно ресурсов.
Я на третьем месте в общем списке игроков этой чёртовой игры.
Но ты, Цуми, видимо, не поняла, что я хочу тебя добиться.
Мы с тобой всего в нескольких шагах к становлению парой.
Будь у тебя в твоём компьютерном мозге больше извилин...
...Ты бы поняла, что многое теряешь со своими подружками.
В твоих интересах быть паинькой.
Я одеваю тебя, покупаю тебе еду, даю ночевать в своём виртуальном пентхаусе.
Может, если ты наконец-то задумаешься о том, как я тебя ценю...
...ты перехочешь обращать внимание на всякие пустяки.
Пойми, что...

 
* [Цуми, ты нужна мне.]
{next("Level6")}
-->END
-->END
-->END
