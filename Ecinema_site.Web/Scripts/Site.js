// Add any custom JavaScript functionality here
$(document).ready(function() {
    // Example: Add smooth scrolling to all links
    $('a[href^="#"]').on('click', function(event) {
        var target = $(this.getAttribute('href'));
        if (target.length) {
            event.preventDefault();
            $('html, body').stop().animate({
                scrollTop: target.offset().top
            }, 1000);
        }
    });

    // Example: Add active class to current nav item
    var currentLocation = window.location.pathname;
    $('.nav-link').each(function() {
        var $this = $(this);
        if ($this.attr('href') === currentLocation) {
            $this.addClass('active');
        }
    });
}); 