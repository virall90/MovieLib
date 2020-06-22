﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLib.Data.Models;

namespace MovieLib.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.CreatedByUser)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.CreatedByUserId);

            builder.HasData(
                new Movie
                {
                    Id = "1443c32c-1e08-4dc3-8d06-51ccaa975bc3",
                    Name = "Криминальное чтиво",
                    Description =
                        @"Двое бандитов Винсент Вега и Джулс Винфилд ведут философские беседы в перерывах между разборками и решением проблем с должниками криминального босса Марселласа Уоллеса.

В первой истории Винсент проводит незабываемый вечер с женой Марселласа Мией. Во второй рассказывается о боксёре Бутче Кулидже, купленном Уоллесом, чтобы сдать бой. В третьей истории Винсент и Джулс по нелепой случайности попадают в неприятности.",
                    ReleaseYear = 1994,
                    Director = "Квентин Тарантино",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "186c8588-1906-43a6-9d5a-696986f6a77e",
                    Name = "Леон",
                    Description =
                        @"Профессиональный убийца Леон неожиданно для себя самого решает помочь 11-летней соседке Матильде, семью которой убили коррумпированные полицейские.",
                    ReleaseYear = 1994,
                    Director = "Люк Бессон",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "2de3306f-5d1e-4827-acf1-38c6f4370402",
                    Name = "Форрест Гамп",
                    Description =
                        @"От лица главного героя Форреста Гампа, слабоумного безобидного человека с благородным и открытым сердцем, рассказывается история его необыкновенной жизни.

Фантастическим образом превращается он в известного футболиста, героя войны, преуспевающего бизнесмена. Он становится миллиардером, но остается таким же бесхитростным, глупым и добрым. Форреста ждет постоянный успех во всем, а он любит девочку, с которой дружил в детстве, но взаимность приходит слишком поздно.",
                    ReleaseYear = 1994,
                    Director = "Роберт Земекис",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "49a946d0-75de-477b-aa27-7f07e0ec1721",
                    Name = "Крестный отец",
                    Description =
                        @"Криминальная сага, повествующая о нью-йоркской сицилийской мафиозной семье Корлеоне. Фильм охватывает период 1945-1955 годов.

Глава семьи, Дон Вито Корлеоне, выдаёт замуж свою дочь. В это время со Второй мировой войны возвращается его любимый сын Майкл. Майкл, герой войны, гордость семьи, не выражает желания заняться жестоким семейным бизнесом. Дон Корлеоне ведёт дела по старым правилам, но наступают иные времена, и появляются люди, желающие изменить сложившиеся порядки. На Дона Корлеоне совершается покушение.",
                    ReleaseYear = 1972,
                    Director = "Фрэнсис Форд Коппола",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "5b2aa187-190b-4598-9edc-fb96a118553b",
                    Name = "1+1",
                    Description =
                        @"Пострадав в результате несчастного случая, богатый аристократ Филипп нанимает в помощники человека, который менее всего подходит для этой работы, — молодого жителя предместья Дрисса, только что освободившегося из тюрьмы. Несмотря на то, что Филипп прикован к инвалидному креслу, Дриссу удается привнести в размеренную жизнь аристократа дух приключений.",
                    ReleaseYear = 2011,
                    Director = "Оливье Накаш, Эрик Толедано",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "6382b1fd-6a51-4ab1-b6f6-e87e3a767a7b",
                    Name = "Начало",
                    Description =
                        @"Кобб — талантливый вор, лучший из лучших в опасном искусстве извлечения: он крадет ценные секреты из глубин подсознания во время сна, когда человеческий разум наиболее уязвим. Редкие способности Кобба сделали его ценным игроком в привычном к предательству мире промышленного шпионажа, но они же превратили его в извечного беглеца и лишили всего, что он когда-либо любил.

И вот у Кобба появляется шанс исправить ошибки. Его последнее дело может вернуть все назад, но для этого ему нужно совершить невозможное — инициацию. Вместо идеальной кражи Кобб и его команда спецов должны будут провернуть обратное. Теперь их задача — не украсть идею, а внедрить ее. Если у них получится, это и станет идеальным преступлением.

Но никакое планирование или мастерство не могут подготовить команду к встрече с опасным противником, который, кажется, предугадывает каждый их ход. Врагом, увидеть которого мог бы лишь Кобб.",
                    ReleaseYear = 2010,
                    Director = "Кристофер Нолан",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "8ba62d0c-0208-4cb7-9774-a432208895f5",
                    Name = "Зеленая миля",
                    Description =
                        @"Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.",
                    ReleaseYear = 1999,
                    Director = "Фрэнк Дарабонт",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "95f88529-6c4a-44bd-88d3-919809709040",
                    Name = "Жизнь прекрасна",
                    Description =
                        @"Во время Второй мировой войны из Италии в концлагерь были отправлены евреи — отец с маленьким сыном. Жена-итальянка добровольно последовала за ними. В лагере отец сказал мальчику, что всё происходящее вокруг является большой интересной игрой за приз в виде настоящего танка. И этот классный приз достанется тому мальчику, который сможет не попасться на глаза надзирателям.",
                    ReleaseYear = 1997,
                    Director = "Роберто Бениньи",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "adda16f4-4556-4fd7-8b3b-737b9d581000",
                    Name = "Достучаться до небес",
                    Description =
                        @"Судьба сводит героев картины в больнице, где врачи выносят им смертный приговор. Счет времени их жизней идет на часы. Дальнейшие события в фильме разворачиваются в стремительном темпе. Украв машину с миллионом немецких марок в багажнике, они сбегают из больницы.

Их преследуют наемные убийцы, они становятся грабителями поневоле, за ними гонится полиция, они попадают в бордель. Но тем не менее продолжают мчаться вперед, навстречу своей судьбе.",
                    ReleaseYear = 1997,
                    Director = "Томас Ян",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "ba7d7cb8-11a0-432b-890c-27e03501a524",
                    Name = "Побег из Шоушенка",
                    Description =
                        @"Бухгалтер Энди Дюфрейн обвинён в убийстве собственной жены и её любовника. Оказавшись в тюрьме под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны решётки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий живым умом и доброй душой, находит подход как к заключённым, так и к охранникам, добиваясь их особого к себе расположения.",
                    ReleaseYear = 1994,
                    Director = "Фрэнк Дарабонт",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "bc0d0f19-567d-4b10-b767-3b504588a8fe",
                    Name = "Иван Васильевич меняет профессию",
                    Description =
                        @"Инженер-изобретатель Тимофеев сконструировал машину времени, которая соединила его квартиру с далеким шестнадцатым веком — точнее, с палатами государя Ивана Грозного. Туда-то и попадают тезка царя пенсионер-общественник Иван Васильевич Бунша и квартирный вор Жорж Милославский.

На их место в двадцатом веке «переселяется» великий государь. Поломка машины приводит ко множеству неожиданных и забавных событий…",
                    ReleaseYear = 1973,
                    Director = "Леонид Гайдай",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "c8ec8902-1155-49a0-883e-329fd16171df",
                    Name = "Список Шиндлера",
                    Description =
                        @"Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев.",
                    ReleaseYear = 1993,
                    Director = "Стивен Спилберг",
                    CreatedByUserId = "ec6439fb-f16d-4c30-9e64-13cb23ca6455",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "d68c1d3d-be23-4da6-8daa-7b3b0997be3f",
                    Name = "Король Лев",
                    Description =
                        @"У величественного Короля-Льва Муфасы рождается наследник по имени Симба. Уже в детстве любознательный малыш становится жертвой интриг своего завистливого дяди Шрама, мечтающего о власти.

Симба познаёт горе утраты, предательство и изгнание, но в конце концов обретает верных друзей и находит любимую. Закалённый испытаниями, он в нелёгкой борьбе отвоёвывает своё законное место в «Круге жизни», осознав, что значит быть настоящим Королём.",
                    ReleaseYear = 1994,
                    Director = "Роджер Аллерс, Роб Минкофф",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                },
                new Movie
                {
                    Id = "dd19ef27-7ef7-41ad-a230-747345e00b94",
                    Name = "Бойцовский клуб",
                    Description =
                        @"Сотрудник страховой компании страдает хронической бессонницей и отчаянно пытается вырваться из мучительно скучной жизни. Однажды в очередной командировке он встречает некоего Тайлера Дёрдена — харизматического торговца мылом с извращенной философией. Тайлер уверен, что самосовершенствование — удел слабых, а единственное, ради чего стоит жить — саморазрушение.

Проходит немного времени, и вот уже новые друзья лупят друг друга почем зря на стоянке перед баром, и очищающий мордобой доставляет им высшее блаженство. Приобщая других мужчин к простым радостям физической жестокости, они основывают тайный Бойцовский клуб, который начинает пользоваться невероятной популярностью.",
                    ReleaseYear = 1999,
                    Director = "Дэвид Финчер",
                    CreatedByUserId = "daab329d-18a7-40cd-b3bf-4681d1949248",
                    HavePoster = true
                }
            );
        }
    }
}