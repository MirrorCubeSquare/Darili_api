﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commingsoon.aspx.cs" Inherits="commingsoon" %>

<!doctype html>

<html lang="en">
<head>
	<meta charset="UTF-8">
	<link rel="stylesheet" href="/css/normalize.css">
	<link rel="stylesheet" href="/css/comingsoonstyle.css">
	<title>event comingsoon</title>
</head>
<body background = "../img/cs-bg.png">
	<div id="container">
		<div >
			<h4>想率先成为风尚引领者？</h4>
		</div>
		<div>
			<h5>留下邮箱，我们将在第一时间与你分享。</h5>
		</div>
		<form action="commingsoon.aspx" method="post">
			<input type="email" name="mail" id="form_text"/>
			<input type="submit" name="mail" value="" id="form_try" />
		</form>
	</div>
</body>
</html>
