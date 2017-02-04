$.fn.serializeObject = function() {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function() {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
$(document).ready(function() {
    console.log(1);

    $("button[type='submit']").click(function(e) {

        e.preventDefault();
        var flag = false;
        var className = '';
        if ($(".visible").length != 0) {
            className = '.visible .mandatory';
        } else {
            className = '.mandatory';
        }
        $(className).parent().parent().parent().find('input:enabled').each(function(i) {
            var input = $(this);
            console.log(input.data().insert);
            if (input.hasClass('autocomplete') && (input.data().insert == undefined)) {
                input.addClass('error');
                setTimeout(function() {
                    input.removeClass('error');
                }, 1000)
                flag = true;
                return;
            }
            if (input.attr('name') == 'email') {
                console.log($(this).val().lastIndexOf('@'));
            }
            if (input.attr('type') == 'radio') {
                if ($("input[type='radio'][name='" + input.attr('name') + "']:checked").length == 0) {
                    // var input = $("input[type='radio'][name='" + $(this).attr('name') + "']");
                    input.parent().addClass('error');
                    flag = true;
                    setTimeout(function() {
                        input.parent().removeClass('error');
                    }, 1000);
                }
            }

            if (input.val() == '') {
                input.addClass('error');
                setTimeout(function() {
                    input.removeClass('error');
                }, 1000);
                flag = true;
            }
        });
        if (flag) {
            return false;
        } else {
            // console.log($('form').serializeObject());
            var formClassName = '';
            if ($(".visible").length != 0)
                formClassName = '.visible form';
            else
                formClassName = 'form';
            var data = $(formClassName).serializeObject();
            var autocompletes = $("input.autocomplete");
            var url = $(formClassName).attr('action');
            var type = $(formClassName).attr('method');
            console.log(url, type);
            autocompletes.each(function() {
                // console.log($(this).data());
                var dataObj = $(this).data().insert;
                for (var i in dataObj) {
                    data[i] = dataObj[i];
                }
            });
            $.ajax({
                url: url,
                type: type,
                data: data,
                success: function(data) {
                    console.log(data);
                    console.log($(".container .alert-success"));
                    if ($(".container .alert-success").length > 0) {
                        $(".container .alert-success").css('display', 'block');
                        if ($(".edit-data button[type='reset']").length == 0)
                            $("button[type='reset']").click();

                        setTimeout(function() {
                            window.location.href = window.location.href;

                        }, 1000);
                    }
                    // $(".container .alert-success").css('display', 'block');
                    // setTimeout(function() {
                    //     $(".container .alert-success").css('display', 'none');
                    // }, 2500);
                    // $("input").val('');
                    // $("input[type='radio']").removeAttr('checked');
                },
                error: function(err) {
                    console.log();
                    $(".container .alert-danger>#err-detail").html(err.responseText);
                    $(".container .alert-danger").css('display', 'block');
                    setTimeout(function() {
                        $(".container .alert-danger").css('display', 'none');
                    }, 2500);

                }
            })
        }
        // $("form").serialize();
    });
});