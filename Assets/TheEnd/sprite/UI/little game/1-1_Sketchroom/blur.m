[I,map,alpha] = imread('plaster4s_color1.png');
PSF = fspecial('gaussian',10,10);
edgesTapered = edgetaper(I,PSF);
alpha_filt = edgetaper(alpha,PSF);
%alpha_filt = imfilter(alpha, PSF, 'replicate');
imshow(myfilteredimage)
imwrite(edgesTapered,'plaster4s_color1_.png','Alpha',alpha_filt);
