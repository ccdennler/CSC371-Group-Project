$(function() {
    // Link Targets
    $('a[href][rel="external"]').attr('target', '_blank');
    // Image Title Attributes
    $('img').each(function() {
        $(this).attr('title', $(this).attr('alt'));
    });
    // Disable Submit Buttons
    $('form').submit(function() {
        $('input[type=submit][name!="more"][name!="cancel"]', this).prop('disabled', true);
    });
    // Code Reference
    $('input[value="Code Reference"]').click(function() {
        window.open('/coderef.php', 'coderef', 'width=600,height=700,status=0,toolbar=0,location=0,menubar=0,directories=0,resizable=0,scrollbars=0');
    });
    // Share Buttons
    $('.share').click(function() {
        window.open($(this).attr('href'), 'share', 'width=860,height=500,status=0,toolbar=0,location=0,menubar=0,directories=0,resizable=0,scrollbars=0');
        return false;
    });
    // Spoilers
    $('.spoiler').hover(function() {
        $(this).find('.spoiler-text').css('background-color', '#ffffff');
    }, function() {
        $(this).find('.spoiler-text').css('background-color', '#000000');
    });
    // Toggle Other Systems
    $('#toggle_other').click(function() {
        if($('#other').is(':visible')) {
            $('#other').slideUp('fast');
            $(this).attr('src', '/images/' + theme + '/buttons/nav-closed.png');
            return false;
        } else {
            $('#other').slideDown('fast');
            $(this).attr('src', '/images/' + theme + '/buttons/nav-open.png');
            return false;
        }
    });
    // Toggle Navigation Menu
    $('.nav-header:not(.ad-header)').click(function() {
        var selected = 'left' + $(this).attr('id').split('_')[0];
        if($('#' + selected).is(':visible')) {
           $('#' + selected).slideUp('fast');
           $('#' + selected + '-arrow').attr('src', '/images/' + theme + '/buttons/nav-closed.png');
           if(selected == 'leftnav-consoles' && $('#sidebar-ad')) {
               $('#sidebar-ad').css('display', 'none');
           }
        } else {
           $('#' + selected).slideDown('fast');
           $('#' + selected + '-arrow').attr('src', '/images/' + theme + '/buttons/nav-open.png');
           $('div[id^="leftnav-"][id!="' + selected +'"]').each(function() {
               if($(this).is(':visible')) {
                   $(this).slideUp('fast');
                   $('#' + $(this).attr('id') + '-arrow').attr('src', '/images/' + theme + '/buttons/nav-closed.png');
               }
           });
           if(selected == 'leftnav-consoles') {
               $('#sidebar-ad').css('display', 'block');
           } else {
               $('#sidebar-ad').css('display', 'none');
           }
        }
    });
    // Header Resize on Scroll
    $(document).scroll(function() {
        if($(window).width() > 766 && $(window).height() > 800 && window.location.pathname.indexOf('fullview') < 0) {
            if(typeof window.av_width == 'undefined' || typeof window.av_height == 'undefined') {
                window.av_width = [];
                window.av_height = [];
                window.av_width['large'] = $('#userbox img').width();
                window.av_height['large'] = $('#userbox img').height();
                if(window.av_width['large'] > window.av_height['large']) {
                    window.av_width['small'] = 40;
                    window.av_height['small'] = Math.round(40 / (window.av_width['large'] / window.av_height['large']));
                } else {
                    window.av_width['small'] = Math.round(40 / (window.av_height['large'] / window.av_width['large']));
                    window.av_height['small'] = 40;
                }
            }
            if($(this).scrollTop() > 130) {
                $('#header img:first').attr('src', '/resources/images/' + theme + '/header/logo-small.png');
                $('#userbox img').width(window.av_width['small']).height(window.av_height['small']);
                if($('#userbox div:eq(1):contains("Register today")').length) {
                    $('#userbox div:eq(1)').text('Register today to access all features of the site!');
                } else {
                    $('.small-hide').css('display', 'none');
                }
                $('#header').addClass('small');
                $('#userbox').addClass('small');
                $('#search').addClass('small');
                $('#nav-top').addClass('small');
                $('#userbox.small img').parent().css('width', '40px').css('height', '40px');
                $('#skinleft').css('top', '80px');
                $('#skinright').css('top', '80px');
            } else {
                $('#skinright').css('top', '129px');
                $('#skinleft').css('top', '129px');
                $('#nav-top').removeClass('small');
                $('#search').removeClass('small');
                $('#userbox').removeClass('small');
                $('#header').removeClass('small');
                if($('#userbox div:eq(1):contains("Register today")').length) {
                    $('#userbox div:eq(1)').text('Register today to join in with discussions on the forum, post comments on the site, and upload your own sheets!');
                } else {
                    $('.small-hide').css('display', 'inline-block');
                }
                $('#userbox img').parent().css('width', '74px').css('height', '74px');
                $('#userbox img').width(window.av_width['large']).height(window.av_height['large']);
                $('#header img:first').attr('src', '/resources/images/' + theme + '/header/logo.png');
            }
        }
    });
    // Resize comment images and videos
    $('.commentContent img, #commentList img, #commentList iframe').each(function() {
        var maxWidth = ($(this).parents('#commentList').length ? 200 : 700);
        $(this).on('load', function() {
            if($(this).width() > maxWidth) {
                $(this).width(maxWidth);
                $(this).height(Math.round(maxWidth / ($(this).attr('width') / $(this).attr('height'))));
                if($(this).is('img')) {
                    $(this).css('cursor', 'pointer');
                    $(this).click(function() {
                        window.open($(this).attr('src'), '_blank');
                    });
                }
            }
        });
    });
    // Unhide NSFW Content
    $('.nsfw-warning').click(function() {
        $(this).slideUp('fast');
        $('.nsfw').slideDown('fast');
    });
    // Update Sheet Display Toggle
    $('#toggle-link, #include-sheets').click(function() {
        var word = '';
        switch(location.host) {
            case "www.models-resource.com":
                word = "Models";
                break;
            case "www.sounds-resource.com":
                word = "Sounds";
                break;
            case "www.spriters-resource.com":
                word = "Sheets";
                break;
            case "www.textures-resource.com":
                word = "Textures";
                break;
        }
        // Toggle Sheets on Add Update Page
        if($(this).attr('id') == 'include-sheets') {
            if($(this).is(':checked')) {
                $('#sheets_msg').html('Uncheck to post this update without ' + word.toLowerCase());
            } else {
                $('#sheets_msg').html('Check to include ' + word.toLowerCase() + ' with this update');
            }
        }
        if($('#updatesheets').is(':visible')) {
            $('#updatesheets').slideUp('slow');
            $(this).html('Show ' + word);
        } else {
            $('#updatesheets').slideDown('slow');
            $(this).html('Hide ' + word);
        }
        return $(this).attr('id') == 'include-sheets';
    });
    // Toggle Game Sections
    $('.sect-collapse').click(function() {
        var sect = $(this).parent().next();
        if(sect.is(':visible')) {
            $(this).parent().css('margin-bottom', '10px');
            $(this).children('img').attr('src', '/images/' + theme + '/buttons/nav-closed.png');
            sect.slideUp('fast');
        } else {
            sect.slideDown('fast');
            $(this).parent().css('margin-bottom', '0px');
            $(this).children('img').attr('src', '/images/' + theme + '/buttons/nav-open.png');
        }
    });
    // Toggle Zip Contents
    $('.zip-collapse').click(function() {
        var zip = $(this).parent().next();
        if(zip.is(':visible')) {
            $(this).children('img').attr('src', '/images/' + theme + '/buttons/nav-closed.png');
            zip.slideUp('fast');
        } else {
            zip.slideDown('fast');
            $(this).children('img').attr('src', '/images/' + theme + '/buttons/nav-open.png');
        }
    });
    // Edit Section Form
    $('.edit-section').click(function() {
        if(typeof window.original == 'undefined') {
            window.original = [];
        }
        var id = $(this).attr('id').split('-')[1];
        window.original[id] = $(this).siblings('div.sect-name').text();
        $(this).siblings('div.sect-name').html('<input type="text" name="sect[' + id + ']" id="sect-' + id + '-form" size="40" class="formElement" value="' + $.trim(window.original[id]) + '">');
        $(this).css('display', 'none');
        if(!$('#section-form-buttons').is(':visible')) {
            $('#section-form-buttons').css('display', 'block');
        }
    });
    $('#cancel_sections').click(function() {
        $('#section-form-buttons').css('display', 'none');
        $('input[name^="sect"]').each(function() {
            $(this).parent().siblings('img.edit-section').css('display', 'initial');
            $(this).parent().html(window.original[$(this).attr('id').split('-')[1]]);
        });
    });
    // Confirm Delete
    $('#delete').change(function() {
        var form = $(this).parents('form:first');
        form.submit(function() {
            if($('#delete').is(':checked')) {
                if(confirm('You have marked this item for deletion. If you are sure, click OK. Otherwise, click Cancel.')) {
                    return true;
                } else {
                    form.find('input[type="submit"]').removeProp('disabled');
                    return false;
                }
            } else {
                return true;
            }
        });
    });
    // Toggle New Section Field
    $('#sect, #console').change(function() {
        if($(this).val() == 'new') {
            $('#new-sect').css('display', 'inline');
        } else {
            $('#new-sect').css('display', 'none');
        }
    });
    // Auto-Fill Sheet Name from File Name
    $('#sheet-up').change(function() {
        if($('#name').val() == '') {
            var file = $(this).val();
            var index1 = file.lastIndexOf('\\');
            var index2 = file.lastIndexOf('.');
            var name = file.substring(index1 + 1, index2)
            $('#name').val(name);
        }
    });
    // Auto-Select Radio Buttons and Checkboxes on Forms
    $('input[type!="radio"][type!="checkbox"],textarea[name="other_text"]').change(function() {
        if($(this).prevAll('input[type="radio"], input[type="checkbox"]').length) {
            if($(this).val() != '') {
                $(this).prevAll('input[type="radio"]:first, input[type="checkbox"]:first').prop('checked', true);
                $(this).prevAll('input[type="radio"]:first, input[type="checkbox"]:first').trigger('change');
            } else {
                $(this).prevAll('input[type="checkbox"]:first').removeProp('checked');
                $(this).prevAll('input[type="checkbox"]:first').trigger('change');
            }
        }
    });
    // Toggle Reject Form
    $('[id^="reject-"]').click(function() {
        var id = $(this).attr('id').split('-')[1];
        if($('#reject_' + id).is(':visible')) {
            $(this).html('REJECT');
            $('#reject_' + id).fadeOut('slow');
        } else {
            $(this).html('CANCEL');
            $('#reject_' + id).fadeIn('slow');
        }
        return false;
    });
    // Show Flagged Submission
    $('[id^=show_sub_]').click(function() {
       var id = $(this).attr('id').split('_')[2];
       $('#sub_error_' + id).css('display', 'none');
       $('#sub_info_' + id).fadeIn('slow');
       return false; 
    });
    // Toggle Batch Reject PM
    $('[id="batch_pm"]').change(function() {
        if($(this).is(':checked')) {
            $('#pm_form').fadeIn('slow');
            $('#pm_sendas').fadeIn('slow');
        } else {
            $('#pm_form').fadeOut('slow');
            $('#pm_sendas').fadeOut('slow');
        }
        return false;
    });
    // Confirm Rejections
    $('input[value="Reject"]').click(function() {
        if(confirm('You are about to reject this item. This action cannot be undone. Click OK to continue or Cancel to go back.')) {
            return true;
        } else {
            $(this).removeProp('disabled');
            return false;
        }
    });
    // Confirm Cancellation
    $('.cancel').click(function() {
        return confirm('You are about to cancel this item, permanently removing it from the queue. This action cannot be undone. Click OK to continue or Cancel to go back.');
    });
    // Toggle Update Checkbox on Edit Pages
    $('input[type="radio"][name="stype"]').change(function() {
        if($('#update-row').length) {
            if($(this).val() != 'keep') {
                $('#update-row').fadeIn('slow');
            } else {
                $('#update-row').fadeOut('slow');
            }
        }
    });
    // Toggle Selected Game Status Field
    $('select[id="game"]').change(function() {
        var label = $('#game :selected').parent().attr('label');
        if(label == 'Pending Games') {
            $('#sel_game_status').val('0');
        } else {
            $('#sel_game_status').val('1');
        }
    });
    // Toggle Preserve Shortname Checkbox
    $('#edit_game_name').on('input propertychange paste', function() {
        if($('#game_status').val() == 1 && $('#console').val() == window.console_id) {
            if($(this).val() != window.game_name) {
                $('#preserve_box').fadeIn('slow');
            } else {
                $('#preserve_box').fadeOut('slow');
            }
        }
    });
    // Toggle Auto-Approve Fields
    $('#auto-approve').change(function() {
        if($(this).is(':checked')) {
            $('#row-update').fadeIn('slow');
            $('#update').prop('disabled', false);
            $('#row-notes').fadeOut('slow');
            $('#notes').prop('disabled', true);
        } else {
            $('#row-notes').fadeIn('slow');
            $('#notes').prop('disabled', false);
            $('#row-update').fadeOut('slow');
            $('#update').prop('disabled', true);
        }
    });
    // Update Submission Filter Game Status
    $('#filter_game').change(function() {
        if($(':selected', this).text().indexOf(' (Pending)') > 0 || $(':selected', this).parent().attr('label') == 'Pending Games (New Consoles)') {
            $('#filter_pending').val('true');
        } else {
            $('#filter_pending').val('false');
        }
    });
    // Toggle Report Forms
    $('.report-link').click(function() {
        var reportForm = $('#' + $(this).attr('id') + '-form');
        if(reportForm.is(':visible')) {
            reportForm.fadeOut('slow', function() {
                if($('#game-info-wrapper').length) {
                    $('#game-info-wrapper').css('min-height', $('#game-info-wrapper').height() - reportForm.height());
                }
            });
        } else {
            reportForm.fadeIn('slow');
            if($('#game-info-wrapper').length) {
                $('#game-info-wrapper').css('min-height', $('#game-info-wrapper').height() + reportForm.height());
            }
        }
        return false;
    });
    // Report Replies
    $('input[type="checkbox"][name^="reply-"]').change(function() {
        var id = $(this).attr('id').split('-')[1];
        if($(this).is(':checked')) {
            $('#resolve-' + id).html('Reply Below');
            $('#reply-row-' + id).css('display', 'table-row');
        } else {
            $('#resolve-' + id).html('<a href="/process/resolve/' + id + '/">Resolve</a>');
            $('#reply-row-' + id).css('display', 'none');
        }
    });
    // Edit/Revise/Report Mouse-Overs
    $('img[src$="edit.png"],img[src$="report.png"]').hover(function(e) {
        var title = $(this).attr('src').split('/')[4].split('.')[0];
        $('#' + title + '-title').css('top', e.pageY + 5);
        $('#' + title + '-title').css('left', e.pageX + 5);
        $('#' + title + '-title').fadeIn('fast');
    }, function() {
        $('#' + $(this).attr('src').split('/')[4].split('.')[0] + '-title').fadeOut('fast');
    });
    // Mode Mouse-Overs
    $('a[href^="/setmode/"],a[href^="/setnsfw/"]').hover(function(e) {
        var title = $(this).attr('href').split('/')[1];
        $('#' + title + '-title').css('top', e.pageY + 5);
        $('#' + title + '-title').css('left', e.pageX + 5);
        $('#' + title + '-title').fadeIn('fast');
    }, function() {
        $('#' + $(this).attr('href').split('/')[1] + '-title').fadeOut('fast');
    });
    // Pending List Mouse-Over
    $('#pending-list-toggle').hover(function(e) {
        $('#pending-list-title').css('top', e.pageY + 5);
        $('#pending-list-title').css('left', e.pageX + 5);
        $('#pending-list-title').fadeIn('fast');
    }, function() {
        $('#pending-list-title').fadeOut('fast');
    });
    // Toggle Pending Submission List
    $('#pending-list-toggle').click(function() {
        if($('#pending-list').is(':visible')) {
            $('#pending-list').fadeOut('slow');
            if($('#pending-list-toggle img').length) {
                $('#pending-list-toggle img').attr('src', '/images/' + theme + '/buttons/nav-closed.png');
            }
        } else {
            if($('#pending-list-toggle img').length) {
                $('#pending-list-toggle img').attr('src', '/images/' + theme + '/buttons/nav-open.png');
            }
            $('#pending-list').fadeIn('slow');
        }
        return false;
    });
    // Contact Form Check
    $('input[type="radio"][name="message-type"]').change(function() {
        if($(this).val() == 'yes') {
            $('#message-check').html('<span style="color: #ff0000; font-weight: bold;">Thank you but we are not interested. We are happy with our design, we are doing fine in search results, your WordPress experience will not help with a site this specialized, and we do not need new advertisers or marketing. Take us off of your list and do not attempt to contact us again. Thanks!</span>');
        } else {
            $('#message-check').hide();
            $('#message-form').show();
        }
    });
});