
(function ($) {
    'use strict';

    document.addEventListener('DOMContentLoaded', onReady);
    function onReady() {
        $('#cart-button').on('click', toggleCart);
        $('.cart-dialog').on('click', preventCloseCart);
        $(document).on('click', closeCart);
    }

    function toggleCart(e) {
        e.stopPropagation();
        $('.cart-dialog').toggleClass('cart-dialog--active');
    }

    function preventCloseCart(e) {
        e.stopPropagation();
    }

    function closeCart(e) {
        $('.cart-dialog--active').removeClass('cart-dialog--active');
    }

})(jQuery);