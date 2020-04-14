$(document).ready(function () {
    $.support.placeholder = (function () {
        var i = document.createElement('input');
        return 'placeholder' in i;
    })();
    if ($.support.placeholder) {
        $('.form li').each(function () {
            if (!$(this).hasClass('js-unhighlight-label')) {
                $(this).addClass('js-hide-label');
            }
        });
    }
    $('.form li').find('input, textarea').on('keyup blur focus', function (e) {

        // Cache our selectors
        var $this = $(this),
            $parent = $this.parent();

        // Add or remove classes
        if (e.type == 'keyup') {
            if ($this.val() == '') {
                $parent.addClass('js-hide-label');
            } else {
                $parent.removeClass('js-hide-label');
            }
        }
        else if (e.type == 'blur') {
            if ($this.val() == '') {
                $parent.addClass('js-hide-label');
            }
            else {
                $parent.removeClass('js-hide-label').addClass('js-unhighlight-label');
            }
        }
        else if (e.type == 'focus') {
            if ($this.val() !== '') {
                $parent.removeClass('js-unhighlight-label');
            }
        }
    });
});
$(window).load(function(){
    $("ol.progtrckr").each(function(){
        $(this).attr("data-progtrckr-steps", 
                     $(this).children("li").length);
    });
})
 

 