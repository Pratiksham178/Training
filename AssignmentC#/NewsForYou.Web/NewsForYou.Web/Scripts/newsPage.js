var eachRow = `<div class="each-news-in-slide fade" >
        <img src="[imagesrc]" class="each-image-in-slideshow" newsid="[newsId]"/>
        <div class="title">
            <div>
                <img src="[AgencyImage]" class="agency-image"/>
                <span class="agency-name">[AgencyName]</span>
                <span class="dot"></span>
                <span class="view-number">[ClickCount] views</span>
            </div>
        <div>[Caption Text]</div>
        </div>
</div>`
var eachCategory = `<button class="category-btn" category-id="[catId]">[CategoryName]</button >`
var eachNewsBox = `<div class="news-container" newsId="[newsId]">
                        <div class="image-box" >
                            <img src="[imagesrc]" onerror="this.src='./Images/brokenimage.png'" newsId="[newsId]"/>
                        </div>
                        <div class="title-box"  >
                            <p ><img src="[AgencyImage]" class="agency-image"/>
                                <span class="agency-name">[AgencyName]</span>
                                 <span class="dot"></span>
                                   <span class="view-number">[hours]</span></p>
                            <p newsId="[newsId]">[title]<p>
                        </div>
                    </div>`
var eachButton = `<button class="pagination-btn" pageNo="[pageno]" changePage="no">[pageno]</button>`
let allNews = []
let slideIndex = 1;
var page = 1;
var shownNews = [];
var btnBoxNumber = 1;
$(document).ready(function () {
    //alert for new news
    setInterval(() => {
        $.ajax({
            type: "POST",
            url: "NewsPage.aspx/GetNewNews",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d > allNews.length) {
                    $("#newMessages").empty().append(`<p class="message-alertbox">${response.d - allNews.length} new news<br>Please refresh the page to get the latest results</p>`)
                    $("#refreshpageAlertbox").css({ "display": "block" })
                }
                if (response.d == null){
                    alert("Some error occured");
                }
                

            },
            Error: function (response) {
                alert(response);
            }
        })
        
    }, 300000);
    $("#crossBtnForAlertbox").click(function () {
        $("#refreshpageAlertbox").css({ "display": "none" })
    })

    //get all the news 
    function GetNews() {
        $.ajax({
            type: "POST",
            url: "NewsPage.aspx/GetAllNews",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == null) {
                    alert("Some error occured")
                } else {
                    allNews = response.d.slice();
                    var news = response.d;
                    $(".loading-gif").css({ "display": "none" })
                    $(".categories-btns").css({ "display": "block" });
                    AddSlideShow(news);
                    AddAllNews();
                }
                

            },
            Error: function (response) {
                alert(response);
            }
        })
    }
    GetNews()

    //open news on click
    function OnClickViewNews(id) {
        $.ajax({
            type: "POST",
            url: "NewsPage.aspx/IncreaseClickCountAndReturnLink",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == null) {
                    alert("some error occured")
                } else {
                    window.open(response.d, '_blank');
                }
            },
            Error: function (response) {
                alert(response);
            }
        })
    }
    $("#slideShowNews").on('click','div', (e) => {
        OnClickViewNews($(e.target).attr("NewsID"));
    })
    $("#newsBoxId").on('click', '.news-container', function(e) {
        OnClickViewNews($(this).attr("newsID"))
    });

    //on hover css for the news container
    $("#newsBoxId").on('mouseover', '.news-container', function () {
        $(this).css({ "background-color":"#d6d6c2"})
    });
    $("#newsBoxId").on('mouseout', '.news-container', function () {
        $(this).css({ "background-color": "white" })
    });

    //news container data & pagination

    function GetTime(t) { ///get time for showing when was the news published
        var count = 0;
        t = t / 1000;
        for (i = 0; i < 3;i++) {
            if (t >= 60 & count < 2) {
                t = Math.ceil(t / 60);
                count += 1;
            } else if (t >= 24 & count >= 2) {
                t = Math.ceil(t / 24);
                count += 1;
            } else {
                break;
            }
        }
        if (count == 0) {
            return t + " seconds ago";
        } else if (count == 1) {
            return t + " minutes ago";
        } else if (count == 2) {
            return t + " hours ago";
        } else if (count == 3) {
            return t + " days ago";
        }

    }
    function AddNewsInBox() {  //Addnewsinto the container
        
        if (page * 32 <= shownNews.length) {
            var news = shownNews.slice((page - 1) * 32, page * 32);
        } else {
            var news = shownNews.slice((page - 1) * 32, shownNews.length-1);
        }
        $("#newsBoxId").empty();
        $.each(news, function (index, value) {
            var newsDate = new Date(parseInt(value["NewsPublishDateTime"].substring(6)));
            var time = GetTime(Date.now() - Date.parse(newsDate)).toString();
            var newbox = eachNewsBox.replace("[imagesrc]", value["NewsImageLink"]).replace("[title]", value["NewsTitle"]).replace("[AgencyImage]", value["AgencyImageLink"]).replace("[AgencyName]", value["AgencyName"]).replace("[hours]", time).replace("[newsId]", value["NewsId"]).replace("[newsId]", value["NewsId"]).replace("[newsId]", value["NewsId"]).replace("[newsId]", value["NewsId"]);
            $("#newsBoxId").append(newbox);
        })
       
    }
    function AddPaginationButtons() {
        $("#paginationBtnsDiv").empty();
        var totalNews = shownNews.length;
        var totalPage = Math.ceil(totalNews / 32);
        
        if (totalPage > (btnBoxNumber * 10)) {
            if (btnBoxNumber != 1) {
                $("#paginationBtnsDiv").append(`<button class="alter-pageno-btn" parseBy="-1" changePage="yes">&#10094</button>`)

            }
            for (i = (btnBoxNumber-1)*10 + 1; i <= btnBoxNumber * 10; i++) {
                var newbtn = eachButton.replace("[pageno]", i).replace("[pageno]", i);
                $("#paginationBtnsDiv").append(newbtn)
            }
            $("#paginationBtnsDiv").append(`<button class="alter-pageno-btn" parseBy="1" changePage="yes">&#10095</button>`)
        } else if (totalPage <= btnBoxNumber*10){
            if (btnBoxNumber != 1) {
                $("#paginationBtnsDiv").append(`<button class="alter-pageno-btn" parseBy="-1" changePage="yes">&#10094</button>`)

            }
            for (i = (btnBoxNumber - 1) * 10 +1; i <= totalPage; i++) {
                var newbtn = eachButton.replace("[pageno]", i).replace("[pageno]", i);
                $("#paginationBtnsDiv").append(newbtn)
            }
        }
    }

    $("#paginationBtnsDiv").on('click', 'button', function (e) {
        if ($(this).attr("changePage") == "yes") {
            btnBoxNumber += parseInt($(e.target).attr("parseBy"));
            AddPaginationButtons();
        } else {
            $(".pagination-btn").css({ "background-color": "white", "color": "black" });
            $(this).css({ "background-color": "black", "color": "white" })
            page = $(this).attr("pageNo");
            AddNewsInBox();
            $("#categories")[0].scrollIntoView({
                behavior: "smooth",
                block: "start",
            });
        }
        
    })
    
    function AddAllNews() {
        if (document.cookie != "") {
            var reqCategory = document.cookie.split(";")[0].split("=")[1];
            $("#newsBoxId").empty();
            if (reqCategory != "") {
                var listOfCategory = reqCategory.split(",");
                var allRequiredNews = allNews.filter(function (item) {
                    return listOfCategory.includes(item["CategoryId"].toString())
                });
                shownNews = allRequiredNews

            } else {
                shownNews = allNews;
            }
        } else {
            shownNews = allNews;
        }
        btnBoxNumber = 1;
        AddPaginationButtons();
        AddNewsInBox();
        
    }
    //categories bar
    $("#categories").on('click', '.category-btn', function(e) {
        var id = $(e.target).attr("category-id");
        var cookie = document.cookie;
        if (document.cookie != "") {
            var categoriesRequired = document.cookie.split(";")[0].split("=")[1];
            if (categoriesRequired != "") {
                var listOfCategory = categoriesRequired.split(",");
                if (!listOfCategory.includes(id)) {
                    document.cookie = "categoryId=" + categoriesRequired + "," + id + ";expires=Fri, 31 Dec 9999 21:10:10 GMT";
                    $(this).css({ "background-color": "black", "color": "white", "border-right": "1px solid white" })
                } else {
                    var index = listOfCategory.indexOf(id)
                    listOfCategory.splice(index, 1);
                    document.cookie = "categoryId=" + listOfCategory.toString() + ";expires=Fri, 31 Dec 9999 21:10:10 GMT"
                    $(this).css({ "background-color": "white", "color": "black", "border-right": "1px solid black" });
                }

            }
            else {
                document.cookie = "categoryId=" + id;
                $(this).css({ "background-color": "black", "color": "white", "border-right": "1px solid white" })

            }
        } else {
            document.cookie = "categoryId=" + id;
        }

        btnBoxNumber = 1;
        page = 1;
        AddAllNews();
        
        

    })

    $.ajax({
        type: "POST",
        url: "NewsPage.aspx/GetallCategories",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == null) {
                alert("Some Error occured")
            } else {
                AddCategory(response.d);
            }
        },
        Error: function (response) {
            alert(response);
        }
    })
    function AddCategory(data) {
        var listOfCategory=[]
        if(document.cookie != "") {
            var categoriesRequired = document.cookie.split(";")[0].split("=")[1];
            if (categoriesRequired != "") {
                listOfCategory = categoriesRequired.split(",");
            }
        }
        $.each(data, function (index, value) {
            
            var newCategory = eachCategory.replace("[catId]", value["CategoryId"]).replace("[CategoryName]", value["CategoryName"])
            $("#categories").append(newCategory);
            
        })
        var allCategories = $(".category-btn");
        $.each(allCategories, function (index, value) {
            if (listOfCategory.includes($(value).attr("category-id"))) {
                $(value).css({ "background-color": "black", "color": "white", "border-right": "1px solid white" });
            }
        })

    }

    //slideshow
    function Compare(a, b) {
        if (a["ClickCount"] < b["ClickCount"]) {
            return 1;
        } else if (a["ClickCount"] > b["ClickCount"]) {
            return -1;
        } else {
            return 0;
        }
    }
    function AddSlideShow(data) {
        var slideShowData = data.sort(Compare).slice(0, 5);
        $.each(slideShowData, function (index, value) {
            var addNewSlide = eachRow.replace("[newsId]", value["NewsId"]).replace("[imagesrc]", value["NewsImageLink"]).replace("[Caption Text]", value["NewsTitle"]).replace("[AgencyImage]", value["AgencyImageLink"]).replace("[ClickCount]", value["ClickCount"]).replace("[AgencyName]", value["AgencyName"])
            $("#slideShowNews").append(addNewSlide);
        })
        $("#slideShowNews").append(`<a class="prev" parseBy="-1">&#10094;</a>
                        <a class="next" parseBy="1">&#10095;</a>`);

        ShowSlides(slideIndex);
    }

    $("#slideShowNews").on('click', 'a', (e)=> {
        PlusSlides(parseInt($(e.target).attr("parseBy")))
    })

    function PlusSlides(n) {
        ShowSlides(slideIndex += n);
    }

    function ShowSlides(n) {
        let i;
        let slides = $(".each-news-in-slide")
        if (n > slides.length) { slideIndex = 1 }
        if (n < 1) { slideIndex = slides.length }
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slides[slideIndex - 1].style.display = "block";
    }

    
})