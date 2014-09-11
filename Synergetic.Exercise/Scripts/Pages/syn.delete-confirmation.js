$.fn.deleteConfirmation = function (callback, options) {
    var $this = this;

    var defaults = {
        deleteUrl: $this.attr('href'),
        message: 'Are you sure that you want to delete this record?'
    };
    
    if (options) {
        $this.options = $.extend({}, defaults, options);
    }
    else {
        $this.options = defaults;
    }

    $this.on('click', function (e) {
        e.preventDefault();
        if (confirm($this.options.message)) {
            $.ajax({
                url: $this.options.deleteUrl,
                type: 'POST',
                success: function (data) {
                    if (data === 'OK') {
                        callback.call();
                    }
                },
                error: function (error) {
                    alert('An error has occured: ' + error);
                }
            });
        };
    });
};