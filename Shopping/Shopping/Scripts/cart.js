$(document).ready(function(){
	//添加
  $(".add").click(function(){
	//获取个数
	//alert("add");
	var c = parseInt($(this).siblings("span").text());
	//判断是否还可以再加
	if(c>=3)
		alert("限购哦，亲~");
	else
	{
		c++;
		$(this).siblings("span").text(c);
		var d = $(this).parents(".number").prev().text().substring(1);
		$(this).parents(".text-center").find(".Subtotal").text("￥" + (c * d).toFixed(2));
	}
	changemoney();
  });
  
  //减少
  $(".sub").click(function(){
	//获取个数
	var c = parseInt($(this).siblings("span").text());
	//判断是否还可以再减
	if(c<=1)
		alert("真的不能再减了");
	else
	{
		c--;
		$(this).siblings("span").text(c);
		var d = $(this).parents(".number").prev().text().substring(1);
		$(this).parents(".text-center").find(".Subtotal").text("￥" + (c * d).toFixed(2));
	}
	changemoney();
  });
  
  
  $("input[type='checkbox']").on("click",function(){
	  //选中状态
	  var state = $(this).is(":checked");
	  //全选
	  var checkallstate = $(this).hasClass("checkall");
	  
	  
	  //选中
	  if(state)
	  {
		  //全选
		  if(checkallstate)
		  {
			  //全选
			  $("input[type='checkbox']").each(function(){
				  this.checked=true;
			  });
			  //alert("nihao");
			 
		  }
		  else
		  {
			  
			  $(this).checked = true;
			  //为了判断全选是否选上
                var c = $("input[type='checkbox']:checked").length;
                var d = $("input").length - 1;
                if (c == d) {
                    $("input[type='checkbox']").each(function () {
                        this.checked = true
                    })
                }
              
		  }
	  }
	  else
	  {
		  
		  $(".checkall").attr("checked", false);		
		 		  
	  }
	  changemoney();
  });
  
  
  //改变总和
  function changemoney(){
	  //总和
	  //debuger();
	  
	  var sum=0;
	  //个数
	  var num = $(".text-center input[type='checkbox']:checked").length;
	  if(num==0)
	  {
		  $("#money").text("￥" + parseFloat(0).toFixed(2));
	  }
	  else
	  {
		  $(".text-center input[type='checkbox']:checked").each(function(){
			  //获取小计
			  var item = $(this).parents(".row").parent().siblings(".Subtotal").text().substring(1);
			  //alert(item);
			  sum+=parseFloat(item);
			  //更改总和
			  $("#money").text("￥" + sum.toFixed(2))
		  });
	  }
	  changenumber();
  }
  
  //改变总件数
  function changenumber(){
	  //alert("nihao");
	  //总件数
	  var cnt=0;
	  //alert(cnt);
	  //单行件数数组
	  var c = $(".text-center input[type='checkbox']:checked").parents(".text-center").find(".number span");
	  //alert(c);
	  var len = c.length;
	  if(len==0)
	  {
		  //alert(0);
		  $("#allnumber").text(0);
	  }
	  else
	  {
		  //alert(1);
		  //alert(c.text());
		  c.each(function(){
			  //alert($(this).text());
			  cnt+=parseInt($(this).text());
			  $("#allnumber").text(cnt);
		  });
	  }
	  //更改按钮状态
	  if ($("#allnumber").text() > 0) { 
		$(".mybtn").removeClass("btn-default active");
		$(".mybtn").addClass("btn-danger");
            
        } else {
		$(".mybtn").addClass("btn-default active");       
		$(".mybtn").removeClass("btn-danger");
        }
  }

   
  
});