(function ($) {
    $.fn.ibox = function () {

        // set zoom ratio //
        resize = 300;
        ////////////////////
        var img = this;
        img.parent().append('<div id="ibox" />');
        var ibox = $('#ibox');
        var elX = 0;
        var elY = 0;

        img.each(function () {
            var el = $(this);

            el.mouseenter(function () {
                ibox.html('');
                var elH = el.height();
                elX = el.position().left - 6; // 6 = CSS#ibox padding+border
                elY = el.position().top - 6;
                var h = el.height();
                var w = el.width();
                var wh;
                checkwh = (h < w) ? (wh = (w / h * resize) / 2) : (wh = (w * resize / h) / 2);

                $(this).clone().prependTo(ibox);
                ibox.css({
                    top: elY + 'px',
                    left: elX + 'px'
                });

                ibox.stop().fadeTo(200, 1, function () {
                    $(this).animate({ top: '-=' + (resize / 2), left: '-=' + wh }, 400).children('img').animate({ height: '+=' + resize }, 400);
                });
            });

            ibox.mouseleave(function () {
                ibox.html('').hide();
            });

            ibox.click(function () {
                ibox.html('').hide();
            });
        });
    };
})(jQuery);


//MODEL BOX
(function ($) {

    $('*[data-reveal-id]').live('click', function (e) {
        //e.preventDefault();
        var modalLocation = $(this).attr('data-reveal-id');
        $('#' + modalLocation).reveal($(this).data());
    });

    $.fn.reveal = function (options) {


        var defaults = {
            animation: 'fadeAndPop', //fade, fadeAndPop, none
            animationspeed: 300, //how fast animtions are
            closeonbackgroundclick: true, //if you click background will modal close?
            dismissmodalclass: 'close-reveal-modal' //the class of a button or element that will close an open modal
        };

        //Extend dem' options
        var options = $.extend({}, defaults, options);

        return this.each(function () {

            var modal = $(this),
                topMeasure = parseInt(modal.css('top')),
                topOffset = modal.height() + topMeasure,
                locked = false,
                modalBG = $('.reveal-modal-bg');

            if (modalBG.length == 0) {
                modalBG = $('<div class="reveal-modal-bg" />').insertAfter(modal);
            }
            //Entrance Animations
            modal.bind('reveal:open', function () {
                modalBG.unbind('click.modalEvent');
                $('.' + options.dismissmodalclass).unbind('click.modalEvent');
                if (!locked) {
                    lockModal();
                    if (options.animation == "fadeAndPop") {
                        modal.css({ 'top': $(document).scrollTop() - topOffset, 'opacity': 0, 'visibility': 'visible' });
                        modalBG.fadeIn(options.animationspeed / 2);
                        modal.delay(options.animationspeed / 2).animate({
                            "top": $(document).scrollTop() + topMeasure + 'px',
                            "opacity": 1
                        }, options.animationspeed, unlockModal());
                    }
                    if (options.animation == "fade") {
                        modal.css({ 'opacity': 0, 'visibility': 'visible', 'top': $(document).scrollTop() + topMeasure });
                        modalBG.fadeIn(options.animationspeed / 2);
                        modal.delay(options.animationspeed / 2).animate({
                            "opacity": 1
                        }, options.animationspeed, unlockModal());
                    }
                    if (options.animation == "none") {
                        modal.css({ 'visibility': 'visible', 'top': $(document).scrollTop() + topMeasure });
                        modalBG.css({ "display": "block" });
                        unlockModal()
                    }
                }
                modal.unbind('reveal:open');
            });

            //Closing Animation
            modal.bind('reveal:close', function () {
                if (!locked) {
                    lockModal();
                    if (options.animation == "fadeAndPop") {
                        modalBG.delay(options.animationspeed).fadeOut(options.animationspeed);
                        modal.animate({
                            "top": $(document).scrollTop() - topOffset + 'px',
                            "opacity": 0
                        }, options.animationspeed / 2, function () {
                            modal.css({ 'top': topMeasure, 'opacity': 1, 'visibility': 'hidden' });
                            unlockModal();
                        });
                    }
                    if (options.animation == "fade") {
                        modalBG.delay(options.animationspeed).fadeOut(options.animationspeed);
                        modal.animate({
                            "opacity": 0
                        }, options.animationspeed, function () {
                            modal.css({ 'opacity': 1, 'visibility': 'hidden', 'top': topMeasure });
                            unlockModal();
                        });
                    }
                    if (options.animation == "none") {
                        modal.css({ 'visibility': 'hidden', 'top': topMeasure });
                        modalBG.css({ 'display': 'none' });
                    }
                }
                modal.unbind('reveal:close');
            });

            modal.trigger('reveal:open')

            //Close Modal Listeners
            var closeButton = $('.' + options.dismissmodalclass).bind('click.modalEvent', function () {
                modal.trigger('reveal:close')
            });

            if (options.closeonbackgroundclick) {
                modalBG.css({ "cursor": "pointer" })
                modalBG.bind('click.modalEvent', function () {
                    modal.trigger('reveal:close')
                });
            }
            $('body').keyup(function (e) {
                if (e.which === 27) { modal.trigger('reveal:close'); } // 27 is the keycode for the Escape key
            });
            function unlockModal() {
                locked = false;
            }
            function lockModal() {
                locked = true;
            }

        });
    }
})(jQuery);



$(document).ready(function () {
    $('*[model-data]').click(function () {
        $('*[model-name=' + $(this).attr('model-data') + ']').fadeIn(500);
        initialize();
        //alert(window.localStorage.getItem("lat") + " - " + window.localStorage.getItem("lng"));
        gmapss(window.localStorage.getItem("lat"), window.localStorage.getItem("lng"));
        //paketHarita(window.localStorage.getItem("lat"), window.localStorage.getItem("lng"));
    });

    $('.popUp-chBox .model').click(function (e) {
        e.stopPropagation();
    });

    $('.popUp-chBox').click(function () {
        $(this).fadeOut(500);
    });
});


$.fn.scrollTo = function (target, options, callback) {

    if (typeof options === 'function' && arguments.length === 2) {

        callback = options;
        options = target;
    }

    var settings = $.extend({
        scrollTarget: target,
        offsetTop: 350,
        duration: 0,
        easing: 'linear'
    }, options);

    return this.each(function (i) {

        var scrollPane = $(this);
        var scrollTarget = (typeof settings.scrollTarget === 'number') ? settings.scrollTarget : $(settings.scrollTarget);
        var scrollY = (typeof scrollTarget === 'number') ? scrollTarget : scrollTarget.offset().top + scrollPane.scrollTop() - parseInt(settings.offsetTop, 10);

        scrollPane.animate({ scrollTop: scrollY }, parseInt(settings.duration, 10), settings.easing, function () {

            if (typeof callback === 'function') {

                callback.call(this);
            }

        });

    });

};




$.fn.autoComplate = function (ayar) {

    var varsayilan = {
        url: 'url',
        culture: 'tr',
        icon: 'hotelsearchicon.png'
    };
    var ayar = $.extend(varsayilan, ayar);
    var els = $(this);
    var text = '';
    var isfocus = false;
    var isClick = false;
    var isEnter = false;
    var Ajaxrequest;
    //console.log('ajax req oluştu:' + Ajaxrequest);
    //var SearchTimer;
    var scroll;
    return this.each(function () {

        els.find('input[type=text]').bind('focus', function (event) {

            isEnter = false;

            var textb = $(this);

            text = textb.val();

            if (!(text.length > 2)) {
                if (varsayilan.culture == "tr")
                    els.find('ul').html('<li>Aramaya Başlamak için 3 Karakter Girin</li>').slideDown();
                else
                    els.find('ul').html('<li>Please Enter 3 More Characters.</li>').slideDown();
            } else {
                els.find('ul').slideDown('');

                if (text != '') {
                    textb.val(text);
                }
            }
        });

        els.find('input[type=text]').on('keyup', function (event) {

            text = $.trim($(this).val());

            isEnter = false;

            if (event.which != 38 && event.which != 40 && event.keyCode != 13) {
                if (text.length >= 3) {

                    isEnter = false;
                    //clearTimeout(SearchTimer);
                    els.find('ul').html('');
                    els.find('ul').slideDown();
                    //els.find('ul').append('<li id="loading"><img src=".../Content/images/loadingOrange.gif" /> ' + (varsayilan.culture == "tr" ? 'Sonuçlar getiriliyor.' : 'Loading.') + '</li>');


                    //SearchTimer = setTimeout(function () {
                    //alert('clear a düştü 1');
                    if (text.length >= 3) {
                        if (Ajaxrequest) {

                            Ajaxrequest.abort();



                        }
                        Ajaxrequest = $.ajax({
                            //async: text.length >= 3 ? false : true,true olacak değiştirme..
                            async: true,
                            type: 'POST',
                            url: ayar.url,
                            data: { "q": text, "culture": ayar.culture },
                            success: function (data) {

                                els.find('ul').html('');
                                //alert('clear a düştü 2');
                                $.each(data, function (i, item) {

                                    var regex = /([A-Z]+){2,3}/;
                                    var isResultCityOTEL = false;
                                    var isResultCityFLİGHT = false;
                                    //alert(item.Item1.indexOf('refid'));
                                    //alert('2 esit:' + item.Item1.indexOf('refid') == -1);
                                    //alert('3 esit:' + item.Item1.indexOf('refid') === -1);
                                    //alert('3 esit:' + item.Item1.indexOf('refid') ===tryp -1);

                                    if (item.Item1.indexOf("refid") == -1) {
                                        isResultCityOTEL = false;
                                    }
                                    else {

                                        isResultCityOTEL = true;
                                    }

                                    if ((item.Item1.indexOf("(Tüm hava limanları)") != -1) || (item.Item1.indexOf("((All Airports))") != -1)) {

                                        isResultCityFLİGHT = true;
                                    }
                                    else {
                                        isResultCityFLİGHT = false;
                                    }



                                    if ((isResultCityOTEL) || (isResultCityFLİGHT)) {


                                        els.find('ul').append('<li iscity="true" ctype="' + item.Item3 + '" data="' + item.Item2 + '"><img src="../Contents/img/car-seracrh-icon.png>"/> ' + item.Item1.replace(text, '<u>' + text + '</u>') + '</li>');
                                    }

                                    else {
                                        //alert(item.Item1 + 'NOT1 city');

                                        els.find('ul').append('<li iscity="false" ctype="' + item.Item3 + '" data="' + item.Item2 + '"><img src="../Contents/img/car-seracrh-icon.png"/> ' + item.Item1.replace(text, '<u>' + text + '</u>') + '</li>');
                                    }

                                    //if ((item.Item1.indexOf("All Airports") > -1) || (item.Item1.indexOf("Tüm hava limanları") > -1)) {
                                    //    els.find('ul').append('<li iscity="true" ctype="' + item.Item3 + '"  data="' + item.Item2 + '">' + item.Item1 + '</li>');
                                    //}
                                    //else {
                                    //    els.find('ul').append('<li iscity="false" ctype="' + item.Item3 + '" data="' + item.Item2 + '">' + item.Item1 + '</li>');
                                    //}
                                });
                                // els.find('ul').find('#loading').hide();
                                //els.find('ul').find('#loading').remove();



                                els.find('ul li:first').addClass('selected');
                                //------------------------------------------------------------------
                                if (parseInt(els.find('ul li:first').attr('data')) > 0) {

                                    els.find('input[type=hidden]').val(els.find('ul li:first').attr('data'));
                                    els.find("input[name=RefID]").val(els.find('ul li b:first').attr('data'));
                                    els.find('input[name*="SearchCityType"]').val(els.find('ul li b:first').attr('ctype'));



                                    var attr = els.find('ul li:first').attr('iscity');
                                    if (typeof attr !== 'undefined' && attr !== false) {
                                        if (els.attr('id') == 'startCityComplate') {
                                            els.find('input[name*="StartAirportIsCity"]').val(attr);
                                        } else if (els.attr('id') == 'endCityComplate') {
                                            els.find('input[name*="EndAirportIsCity"]').val(attr);
                                        }
                                    }






                                }
                                //---------------------------------------------------------------

                                if (data.length == 0) {
                                    els.find('ul').append('<li><font color="#e59729">' + (varsayilan.culture == 'tr' ? 'Sonuç Bulunamadı.' : 'No Result.') + '</font></li>');
                                }
                            }
                        });
                    }
                    //else {
                    //	clearTimeout(SearchTimer);
                    //}
                    //},500);//Delay 0.2MS bu isteğe göre arttırılabilir.//Burda bitiyor.

                    els.find('ul').slideDown();
                    //isEnter = true;
                } else if (text.length == 0) {
                    els.find('ul').slideUp();
                } else {
                    if (varsayilan.culture == "tr")
                        els.find('ul').html('<li>Aramaya Başlamak için 3 Karakter Girin</li>').slideDown();
                    else
                        els.find('ul').html('<li>Please Enter 3 More Characters.</li>').slideDown();

                    els.find('ul').slideDown();
                }
            } else if (event.which == 40) {
                els.find('ul').find('li:not(:last-child).selected').removeClass('selected').next().addClass('selected');
                els.find('ul').scrollTop((els.find('ul').children('.selected').offset().top + els.find('ul').scrollTop()) - parseInt(280, 12));
            } else if (event.which == 38) {
                els.find('ul').find('li:not(:first-child).selected').removeClass('selected').prev().addClass('selected');
                els.find('ul').scrollTop((els.find('ul').children('.selected').offset().top + els.find('ul').scrollTop()) - parseInt(280, 12));
            } else if (event.keyCode == 13) {

                if (parseInt(els.find('ul').find('.selected').attr('data')) > 0) {
                    els.find('input[type=text]').val(els.find('ul').find('.selected').text());
                    els.find('input[type=hidden]').val(els.find('ul').find('.selected').attr('data'));
                    // enter'e basıp arama icin eklendi
                    els.find("input[name=RefID]").val(els.find('ul').find('.selected').children('.refid').attr('data'));
                    els.find('input[name*="SearchCityType"]').val(els.find('ul').find('.selected').attr('ctype'));

                    //
                    var attr = els.find('ul').find('.selected').attr('iscity');
                    if (typeof attr !== 'undefined' && attr !== false) {
                        if (els.attr('id') == 'startCityComplate') {
                            els.find("input[name*='StartAirportIsCity']").val(attr);
                        } else if (els.attr('id') == 'endCityComplate') {
                            els.find("input[name*='EndAirportIsCity']").val(attr);
                        }
                    }




                    els.find('ul').slideUp();
                    isEnter = true;
                    if (els.find('input[type=text]').attr('id') != "endAirport") {

                        els.closest('#endAirport').focus();
                    }

                    if (els.find('input[type=text]').attr('id') == "endAirport") {

                    }
                }
            }

        });

        els.find('ul').delegate('li', 'click', function (event) {
            if (parseInt($(this).attr('data')) > 0) {
                els.find('input[type=text]').val($(this).text());
                els.find('input[type=hidden]').val($(this).attr('data'));




                var attr = $(this).attr('iscity');
                if (typeof attr !== 'undefined' && attr !== false) {
                    if (els.attr('id') == 'startCityComplate') {
                        els.find("input[name*='StartAirportIsCity']").val($(this).attr('iscity'));
                    } else if (els.attr('id') == 'endCityComplate') {
                        els.find("input[name*='EndAirportIsCity']").val($(this).attr('iscity'));
                    }
                }







                els.find('ul').slideUp();
                isClick = false;
                isEnter = true;



            }
        });

        //gereksiz kod başı



        els.find('ul').delegate('li', 'click', function (event) {
            if (parseInt($(this).attr('data')) > 0) {
                els.find('input[type=text]').val($(this).text());
                els.find('input[type=hidden]').val($(this).attr('data'));
                els.find("input[name=RefID]").val($(this).children('.refid').attr('data'));
                els.find('input[name*="SearchCityType"]').val($(this).attr('ctype'));

                if (els.attr('id') == 'vehicleStartRegionComplate') {
                    $('#EndRegion').val($(this).text());
                    $('input[name=EndRegionID]').val($(this).attr('data'));
                }

                var attr = $(this).attr('iscity');
                if (typeof attr !== 'undefined' && attr !== false) {
                    if (els.attr('id') == 'startCityComplate') {
                        els.find("input[name*='StartAirportIsCity']").val($(this).attr('iscity'));
                    } else if (els.attr('id') == 'endCityComplate') {
                        els.find("input[name*='EndAirportIsCity']").val($(this).attr('iscity'));
                    }
                }



                var attr = $(this).attr('iscity');
                if (typeof attr !== 'undefined' && attr !== false) {
                    if (els.attr('id') == 'startCityComplate1') {
                        els.find("input[name*='StartAirportIsCity']").val($(this).attr('iscity'));
                    } else if (els.attr('id') == 'endCityComplate1') {
                        els.find("input[name*='EndAirportIsCity']").val($(this).attr('iscity'));
                    }
                }



                els.find('ul').slideUp();
                isClick = false;
                isEnter = true;
                if (els.find('input[type=text]').attr('id') != "endAirport") {


                    if (els.find('input[type=text]').attr('id') == "startAirport1") {
                        $('#endAirport1').focus();
                    }

                    else if (els.find('input[type=text]').attr('id') == "startAirport") {
                        $('#endAirport').focus();
                    }
                    else {

                    }




                }

                if (els.find('input[type=text]').attr('id') == "endAirport") {
                    console.log('LeaveAts');
                    $('#LeaveAts').trigger('click');
                }
            }
        });

        els.find('input[type=text]').bind('focusout', function (e) {
            //els.find('ul').slideUp();
        });

        //gereksiz sonu

        $(document).bind('click', function () {

            if (document.activeElement.tagName != 'INPUT') {
                els.find('ul').slideUp();
            }
        });

        $(document).bind('keydown', function (event) {

            if (event.keyCode == 13) {
                if (isEnter == false) {
                    event.preventDefault();
                    event.stopPropagation();
                    isEnter = true;
                }
            }
        });

    });
}



$.fn.validate = function (ayar) {
    var varsayilan = {
        type: 'onlyString',
        length: 0
    };
    var ayar = $.extend(varsayilan, ayar);
    var els = $(this);
    var text = $(this).val();

    return this.each(function () {

        els.keypress(function (e) {

            //alert(e.which);

            if (ayar.type == 'onlyString') {
                if ((((e.which < 65 || e.which > 90) && (e.which < 97 || e.which > 122)) && ((e.which != 32 && e.which != 231 && e.which != 287 && e.which != 246 && e.which != 305 && e.which != 252 && e.which != 246 && e.which != 351) && (e.which != 32 && e.which != 199 && e.which != 350 && e.which != 304 && e.which != 286 && e.which != 220 && e.which != 214)) && e.which != 8 && e.which != 46) || (ayar.length > 0 && els.val().length == ayar.length && e.which != 8 && e.which != 46)) {
                    return false;
                }
            } else if (ayar.type == 'onlyNumber') {
                if (((e.which < 48 || e.which > 57) && e.which != 43 && e.which != 8 && e.which != 46) || (ayar.length > 0 && els.val().length == ayar.length && e.which != 8 && e.which != 46)) {
                    return false;
                } else {
                    if (els.val().length != 0 && e.which == 43) {
                        return false;
                    }
                }
            }
        });

    });
}