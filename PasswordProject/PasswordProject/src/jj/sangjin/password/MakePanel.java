package jj.sangjin.password;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.StringSelection;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class MakePanel extends JPanel{     //���θ޴����� �н����� ����⸦ Ŭ�������� ������ �г�
	
	private static int width = 600;
	private static int height = 500;   // ȭ��ũ�� 
	protected int makeback = 0;    // ���θ޴��� ���ư��� ���� ���ں��� 
	protected int makeScreen = 0;   //  �� �гο��� ȭ�� ��ȯ�� ���� ���ں���
	/*int convertPassword = 0;  */
	private int[] tmp = new int[50];    //  input�� �Է��� ������ ���ڰ��� �����ϴ� �迭
	private int i = 0;   // �ݺ��� �������� ����
	private char[] element = new char[20];  // tmp�� ���ڷ� ������ ����� �� ������ ���� ���� �ƽ�Ű �ڵ�� �ؼ� ���� ���ڸ� �����ϴ� �迭

	private String stringTemp = null;  // element�迭�� ���ո� ������ �����ϴ� ����
	private int passwordLength;   // ��й�ȣ ���̸� �󸶷� ���� ����ڰ� �Է��� ���� 

	
	private JButton backButton;  // ������� �ڷΰ��� ��ư
	private JButton exitButton;  //  ������� �����ư
	private JButton inputFinishButton; // �Է¿Ϸ��ư
	private JButton koreanBackButton;  // �Է¿Ϸ��ư ������ �ڷΰ��� ��ư
	private JButton saveFileButton; // �����ϱ� ��ư
	private JButton gomainButton; // ����ȭ������ ���� ��ư 
	private JButton bigGomainButton;    // ��� �Է��ϰ� �������� ���ư��� ��ư 
	private JTextField inputField;   // �� �Է��� �ؽ�Ʈ�ʵ�
	private JTextField inputNumberField;  // �����ȣ ���� �󸶷� ���� �Է��� �ؽ�Ʈ�ʵ�
	private JTextField placeInputField;   // ��𿡼� ������� �Է��� �ؽ�Ʈ�ʵ�
	private JTextArea password;  //  �н����� �����Ȱ� ǥ�õ� �ؽ�Ʈ������
 	private Font fieldFont;   // �ؽ�Ʈ�ʵ忡 ������ ���� 
	private Font passwordFont;  // �ϼ��� �н����带 ������


	private BufferedImage order;  // �� �Է��ϼ��� �̹���
	private BufferedImage finishText;  // �н����� ���� �Ϸ�Ǿ����ϴ� �̹���
	private BufferedImage numberOrder;//  �н����� �ڸ��� �Է��ϼ��� �̹���
	private BufferedImage passwordBackground;  //������� �н����� ���� �̹���
	private BufferedImage placeOrder; // ��� �Է��ϼ��� �̹���
	private ImageIcon backButtonImage = new ImageIcon("back.png");
	private ImageIcon backButtonEnteredImage = new ImageIcon("backEntered.png");
	private ImageIcon exitButtonImage = new ImageIcon("exit.png");
	private ImageIcon exitButtonEnteredImage = new ImageIcon("exitEntered.png");
	private ImageIcon inputFinishButtonImage = new ImageIcon("inputFinish.png");
	private ImageIcon inputFinishButtonEnteredImage = new ImageIcon("inputFinishEntered.png");
	private ImageIcon koreanBackButtonImage = new ImageIcon("koreanBack.png");
	private ImageIcon koreanBackButtonEnteredImage = new ImageIcon("koreanBackEntered.png");
	private ImageIcon gomainButtonImage = new ImageIcon("gomain.png");
	private ImageIcon gomainButtonEnteredImage = new ImageIcon("gomainEntered.png");
	private ImageIcon saveFileButtonImage = new ImageIcon("saveFile.png");
	private ImageIcon saveFileButtonEnteredImage = new ImageIcon("saveFileEntered.png");
	private ImageIcon bigGomainButtonImage = new ImageIcon("bigGomain.png");
	private ImageIcon bigGomainButtonEnteredImage = new ImageIcon("bigGomainEntered.png");   // ��ư�� ���� �̹���������
	
	
	public MakePanel() {
		
		try {
			order = ImageIO.read(new File("MakeOrder.png"));
			finishText = ImageIO.read(new File("finishText.png"));
			numberOrder = ImageIO.read(new File("MakeNumberOrder.png"));
			passwordBackground = ImageIO.read(new File("passwordBackground.png"));  // ���� ���۵��̹������� ���� �д� �ڵ� 
			placeOrder = ImageIO.read(new File("placeOrder.png"));
		}catch(IOException e) {};
		
		this.setLayout(null);   // ��ġ�� �η��Ѵ� 
		fieldFont   = new Font("Serif",Font.PLAIN,17);   //�ؽ�Ʈ�ʵ� ��Ʈ
		passwordFont = new Font("Serif",Font.BOLD,21);  // TextArea��Ʈ
		backButton = new JButton(backButtonImage);  
		exitButton = new JButton(exitButtonImage);
		inputFinishButton = new JButton(inputFinishButtonImage);
		koreanBackButton = new JButton(koreanBackButtonImage);
		gomainButton = new JButton(gomainButtonImage);
		saveFileButton = new JButton(saveFileButtonImage);
		bigGomainButton = new JButton(bigGomainButtonImage);  // ��ư �����ڷ� �̹����� �־ �����Ѵ�

		inputField = new JTextField(50);
		inputNumberField = new JTextField(50);
		placeInputField = new JTextField(50);
		password = new JTextArea(5,50);   // �ؽ�Ʈ�ʵ�� ������� ũ�⸦ �����Ѵ� 
		inputField.setFont(fieldFont);
		inputNumberField.setFont(fieldFont);  // ���� ��Ʈ�� �־��ش�
		password.setFont(passwordFont);
		placeInputField.setFont(fieldFont);
		inputNumberField.setText("0"); // �����ȳ��� ���ڸ� �־��ش� 

		

		backButton.setBorderPainted(false);
		backButton.setContentAreaFilled(false);
		backButton.setFocusPainted(false);     // ��ư �̹����� png���ϴ�� ���̰� �ϱ� ���� �ڵ�
		backButton.setBounds(0,0,86,80);   // ��ư ��ġ
		exitButton.setBorderPainted(false);
		exitButton.setContentAreaFilled(false);
		exitButton.setFocusPainted(false);
		exitButton.setBounds(width-100, 0,86,80);
		inputField.setBounds(100,250,400,30);
		inputNumberField.setBounds(100,250,400,30);
		placeInputField.setBounds(100,250,400,30);
		inputFinishButton.setBorderPainted(false);
		inputFinishButton.setContentAreaFilled(false);
		inputFinishButton.setFocusPainted(false);
		inputFinishButton.setBounds(100,290,192,62);
		koreanBackButton.setBorderPainted(false);
		koreanBackButton.setContentAreaFilled(false);
		koreanBackButton.setFocusPainted(false);
		koreanBackButton.setBounds(300,290,192,62);
		password.setBounds(110,270,375,60);
		gomainButton.setBorderPainted(false);
		gomainButton.setContentAreaFilled(false);
		gomainButton.setFocusPainted(false);
		gomainButton.setBounds(300,360,192,62);
		saveFileButton.setBorderPainted(false);
		saveFileButton.setContentAreaFilled(false);
		saveFileButton.setFocusPainted(false);
		saveFileButton.setBounds(100,360,192,62);
		bigGomainButton.setBorderPainted(false);
		bigGomainButton.setContentAreaFilled(false);
		bigGomainButton.setFocusPainted(false);
		bigGomainButton.setBounds(140,300,300,70);
		this.requestFocus();
		setFocusable(true);


		backButton.addMouseListener(new MouseAdapter(){  //������� �ڷΰ��� ��ư �̺�Ʈ  
			public void mousePressed(MouseEvent e) {  //Ŭ���Ͽ����� 
				if(makeScreen == 0) {   // �г� ù ȭ���̸� �����гη� ���ư����Ѵ�
				makeback = 1;
				inputField.setText("");
				inputNumberField.setText("0");
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
				if(makeScreen == 1) {   // �г� �� ��° ȭ���̸� ù ��° ȭ������ 
					inputField.setVisible(true);
					inputNumberField.setVisible(false);
					makeScreen = 0;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				
				}
				if(makeScreen == 2) {  // �г� 3��° ȭ���̸� 2��° ȭ������ 
					inputNumberField.setVisible(true);
					inputFinishButton.setVisible(true);
					koreanBackButton.setVisible(true);
					password.setVisible(false);
					gomainButton.setVisible(false);
				    saveFileButton.setVisible(false);
				    makeScreen =1;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
				if(makeScreen == 3) {  // �г� 4��° ȭ���̸� 3��° ȭ������ 
				    password.setVisible(true);
				    saveFileButton.setVisible(true);
				    gomainButton.setVisible(true);
				    bigGomainButton.setVisible(false);
				    placeInputField.setVisible(false);
				    makeScreen =2;
					backButton.setIcon(backButtonImage);
					backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
			}
			public void mouseEntered(MouseEvent e) {    // ���콺�� ��ư���� ������ 
				backButton.setIcon(backButtonEnteredImage);
				backButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			public void mouseExited(MouseEvent e) {  // ���콺�� ��ư���� ������ �� 
				backButton.setIcon(backButtonImage);
				backButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});


		this.addKeyListener(new KeyAdapter() {
			public void keyPressed(KeyEvent e) {
				int keycode = e.getKeyCode();
				if(keycode == KeyEvent.VK_BACK_SPACE) {
					if(makeScreen == 0) {   // �г� ù ȭ���̸� �����гη� ���ư����Ѵ�
						makeback = 1;
						inputField.setText("");
						inputNumberField.setText("0");
					}
						if(makeScreen == 1) {   // �г� �� ��° ȭ���̸� ù ��° ȭ������ 
							inputField.setVisible(true);
							inputNumberField.setVisible(false);
							makeScreen = 0;
						}
						if(makeScreen == 2) {  // �г� 3��° ȭ���̸� 2��° ȭ������ 
							inputNumberField.setVisible(true);
							inputFinishButton.setVisible(true);
							koreanBackButton.setVisible(true);
							password.setVisible(false);
							gomainButton.setVisible(false);
						    saveFileButton.setVisible(false);
						    makeScreen =1;
						}
						if(makeScreen == 3) {  // �г� 4��° ȭ���̸� 3��° ȭ������ 
						    password.setVisible(true);
						    saveFileButton.setVisible(true);
						    gomainButton.setVisible(true);
						    bigGomainButton.setVisible(false);
						    placeInputField.setVisible(false);
						    makeScreen =2;
						}
				}
			}
		});

		inputField.addActionListener(e->{
			inputField.setVisible(false);  //  �� �Է� �ʵ带 �Ⱥ��̰� �ϰ� 
			inputNumberField.setVisible(true);   // �н����� ���� �ʵ带 ���̰� �Ѵ� 
			makeScreen = 1;  // 2��° ȭ������ ��ȯ
		});
		
		
		inputNumberField.addActionListener(e->{
		  // �� ��° ȭ�鿡�� ������ �� 
				passwordLength = Integer.parseInt(inputNumberField.getText());  // ��Ʈ������ �Է��� �н����� ���̸� ���ڷ� �ٲ��ش�
				if(passwordLength >= 4 && passwordLength <=20) {  // 4~20�ڸ� ���ڸ� �Է��Ͽ��� ���� ���������� ����
				inputFinishButton.setVisible(false); // �Է��ϱ� ��ư�� ������ �ʰ� �Ѵ�   
				inputNumberField.setVisible(false);  // �����Է��ʵ带 ������ �ʰ� �Ѵ� 
				koreanBackButton.setVisible(false);  // �ڷΰ��� ��ư�� ������ �ʰ� �Ѵ� 
				password.setVisible(true); // ������ �н����尡 �Էµ� �ؽ�Ʈ���� ���̰� �Ѵ� 
				gomainButton.setVisible(true); // �������� ���ư��� ��ư�� ���̰� �Ѵ� 
				saveFileButton.setVisible(true); // ���Ͽ� �����ϱ� ��ư�� ���̰� �Ѵ� 
				inputFinishButton.setIcon(inputFinishButtonImage);  // ȭ�鿡�� ��������ó�� �̹����� Ŀ���� �������´� 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				makeScreen = 2;   //3��° ȭ������ ��ȯ
				for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp�迭�� �ʱ�ȭ�Ѵ�  
				for(i = 0;i < inputField.getText().length(); i++) { 
					tmp[i] =(int) inputField.getText().charAt(i);  // �Է��� �� ���̱��� tmp�迭��  �򹮹����� char�� ���ڰ��� �ִ´� 
				}
				
				
				passwordMake pm = new passwordMake();   // �ؽ���ȣ������ �� �ڸ������� ��ȣ�� ����� �޼ҵ尡 �ִ� ��ä�� �����Ѵ� 
				
				element[0] =(char) pm.oneChange(tmp, inputField.getText().length());
				element[1] =(char) pm.twoChange(tmp, inputField.getText().length());
				element[2] =(char) pm.threeChange(tmp, inputField.getText().length());
				element[3] =(char) pm.fourChange(tmp, inputField.getText().length());  //4~20�ڸ����� ������ 4�ڸ��� �Ǿ �� �ڸ��� �´� �޼ҵ带 ȣ���Ѵ� 
				
				if(passwordLength >= 5) 
					element[4] =(char) pm.fiveChange(tmp, inputField.getText().length());
				if(passwordLength >= 6) 
					element[5] =(char) pm.sixChange(tmp, inputField.getText().length());
				if(passwordLength >= 7) 
					element[6] =(char) pm.sevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 8) 
					element[7] =(char) pm.eightChange(tmp, inputField.getText().length());
				if(passwordLength >= 9) 
					element[8] =(char) pm.nineChange(tmp, inputField.getText().length());
				if(passwordLength >= 10) 
					element[9] =(char) pm.tenChange(tmp, inputField.getText().length());
				if(passwordLength >= 11) 
					element[10] =(char) pm.elevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 12) 
					element[11] =(char) pm.twelveChange(tmp, inputField.getText().length());
				if(passwordLength >= 13) 
					element[12] =(char) pm.thirteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 14) 
					element[13] =(char) pm.fourteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 15) 
					element[14] =(char) pm.fifteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 16) 
					element[15] =(char) pm.sixteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 17)
					element[16] =(char) pm.seventeenChange(tmp, inputField.getText().length());
				if(passwordLength >= 18)
					element[17] =(char) pm.eighteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 19)
					element[18] =(char) pm.nineteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 20)
					element[19] =(char) pm.twentyChange(tmp, inputField.getText().length());  //�Է��� �ڸ������� �޼ҵ带 �����Ѵ� 
				
				for(int i = 0; i < 20; i++)
					if(element[i] < 32)
					System.out.println((int) element[i]);
				element[0] =(char) ((element[0] % 10) + 48);  
				element[1] =(char) ((element[1] % 26) + 97);
				element[2] =(char) ((element[2] % 26) + 65);
				element[3] =(char) ((element[3] % 15) + 33); // ù 4�ڸ��� ������ ����,���ҹ���,���빮�� ,Ư�����ڰ� ���� �Ѵ� 
								
				stringTemp = String.valueOf(element);  //char�� String���� ��ȯ���ش� 
				password.setText(stringTemp);  // ������� �н����带 �ؽ�Ʈ���� �־��ش� 
			    StringSelection stringSelection = new StringSelection(stringTemp);
			    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
			    clipboard.setContents(stringSelection, null);  // ��������� �ڵ����� Ŭ�����忡 ���簡 �ȴ� 

			    stringTemp = inputField.getText();
				inputField.setText("");  
				inputNumberField.setText("0");    
				for(i = 0; i < 20; i++)
					element[i]  = 0;
				}// �� �̿��� ������ �ٽ� �����·� ������Ų�� 
			}
		);
		
		placeInputField.addActionListener(e->{
			makeScreen = 0;   //  ȭ��0���� ��ȯ�Ѵ� 
			makeback = 1;  // ����ȭ������ ���� 
		    bigGomainButton.setVisible(false);   
		    placeInputField.setVisible(false);
			backButton.setVisible(true);
			inputField.setVisible(true);
			inputFinishButton.setVisible(true);
			koreanBackButton.setVisible(true);   //���ο��� �� ��ư ������ �� ù ȭ���� ������ �Ѵ� 
			inputField.setText("");
			inputNumberField.setText("0");         
		    try {                                  
				File outFile= new File("out.txt");       //���� ��ü�� ����� 
				if(!outFile.exists())outFile.createNewFile();  // ������ ������ ����� 
				BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));  // ������ ���� ��ü�� ����� ���� ��ü�� �ִ´� 
				if(placeInputField.getText().equals(""))  // ��Ҹ� ���� �ʾ�����
					bw.write("����  : " + passwordLength + "    "+ "�н����� : " + stringTemp); // �н����常 ���Ͽ� ����ǰ� 
				else bw.write("����� ��� :  " + placeInputField.getText() + "    " + "���� :   " + passwordLength + "    "  + " �н�����  : " + stringTemp);  // �ƴϸ� ���, �н����尡 ����ȴ� 
				bw.newLine();  // �Է��ϰ� �ٹٲ۴� 
				bw.close();   // �Է� �Ϸ��� ���� �ݱ� 
		
		    
		    } catch (IOException e1) {
				e1.printStackTrace();
			}
		    placeInputField.setText("");
			
			
			
		});
		
		
		exitButton.addMouseListener(new MouseAdapter() {  // ������� �����ư 
			public void mousePressed(MouseEvent e) {  //Ŭ���ϸ� ����ȴ�
				System.exit(0);
			}
			@Override
			public void mouseEntered(MouseEvent e) {  // ���콺�� ��ư���� ���� �̹����� Ŀ����  �ٲ�� 
				exitButton.setIcon(exitButtonEnteredImage);
				exitButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // ���콺�� ��ư ������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				exitButton.setIcon(exitButtonImage);
				exitButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		inputFinishButton.addMouseListener(new MouseAdapter() {  // �Է¿Ϸ� ��ư�� ���� ���콺  �̺�Ʈó�� 
			public void mousePressed(MouseEvent e) { // ���콺�� Ŭ���Ͽ���  �� 
				if(makeScreen == 0) {  // ù ��° ȭ�鿡�� �Է� �Ϸ� �������� 
				inputField.setVisible(false);  //  �� �Է� �ʵ带 �Ⱥ��̰� �ϰ� 
				inputNumberField.setVisible(true);   // �н����� ���� �ʵ带 ���̰� �Ѵ� 
				makeScreen = 1;  // 2��° ȭ������ ��ȯ
				inputFinishButton.setIcon(inputFinishButtonImage);   // �̹��� ���콺 ������ �������� ó�� �ǵ��ƿ��� �Ѵ� 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));

				}
				else if(makeScreen == 1) {  // �� ��° ȭ�鿡�� ������ �� 
				passwordLength = Integer.parseInt(inputNumberField.getText());  // ��Ʈ������ �Է��� �н����� ���̸� ���ڷ� �ٲ��ش�
				if(passwordLength >= 4 && passwordLength <=20) {  // 4~20�ڸ� ���ڸ� �Է��Ͽ��� ���� ���������� ����
				inputFinishButton.setVisible(false); // �Է��ϱ� ��ư�� ������ �ʰ� �Ѵ�   
				inputNumberField.setVisible(false);  // �����Է��ʵ带 ������ �ʰ� �Ѵ� 
				koreanBackButton.setVisible(false);  // �ڷΰ��� ��ư�� ������ �ʰ� �Ѵ� 
				password.setVisible(true); // ������ �н����尡 �Էµ� �ؽ�Ʈ���� ���̰� �Ѵ� 
				gomainButton.setVisible(true); // �������� ���ư��� ��ư�� ���̰� �Ѵ� 
				saveFileButton.setVisible(true); // ���Ͽ� �����ϱ� ��ư�� ���̰� �Ѵ� 
				inputFinishButton.setIcon(inputFinishButtonImage);  // ȭ�鿡�� ��������ó�� �̹����� Ŀ���� �������´� 
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				
				makeScreen = 2;   //3��° ȭ������ ��ȯ
				for(i = 0; i < 50; i++) tmp[i] = 0;  //tmp�迭�� �ʱ�ȭ�Ѵ�  
				for(i = 0;i < inputField.getText().length(); i++) { 
					tmp[i] =(int) inputField.getText().charAt(i);  // �Է��� �� ���̱��� tmp�迭��  �򹮹����� char�� ���ڰ��� �ִ´� 
				}
				
				
				passwordMake pm = new passwordMake();   // �ؽ���ȣ������ �� �ڸ������� ��ȣ�� ����� �޼ҵ尡 �ִ� ��ä�� �����Ѵ� 
				
				element[0] =(char) pm.oneChange(tmp, inputField.getText().length());
				element[1] =(char) pm.twoChange(tmp, inputField.getText().length());
				element[2] =(char) pm.threeChange(tmp, inputField.getText().length());
				element[3] =(char) pm.fourChange(tmp, inputField.getText().length());  //4~20�ڸ����� ������ 4�ڸ��� �Ǿ �� �ڸ��� �´� �޼ҵ带 ȣ���Ѵ� 
				
				if(passwordLength >= 5) 
					element[4] =(char) pm.fiveChange(tmp, inputField.getText().length());
				if(passwordLength >= 6) 
					element[5] =(char) pm.sixChange(tmp, inputField.getText().length());
				if(passwordLength >= 7) 
					element[6] =(char) pm.sevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 8) 
					element[7] =(char) pm.eightChange(tmp, inputField.getText().length());
				if(passwordLength >= 9) 
					element[8] =(char) pm.nineChange(tmp, inputField.getText().length());
				if(passwordLength >= 10) 
					element[9] =(char) pm.tenChange(tmp, inputField.getText().length());
				if(passwordLength >= 11) 
					element[10] =(char) pm.elevenChange(tmp, inputField.getText().length());
				if(passwordLength >= 12) 
					element[11] =(char) pm.twelveChange(tmp, inputField.getText().length());
				if(passwordLength >= 13) 
					element[12] =(char) pm.thirteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 14) 
					element[13] =(char) pm.fourteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 15) 
					element[14] =(char) pm.fifteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 16) 
					element[15] =(char) pm.sixteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 17)
					element[16] =(char) pm.seventeenChange(tmp, inputField.getText().length());
				if(passwordLength >= 18)
					element[17] =(char) pm.eighteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 19)
					element[18] =(char) pm.nineteenChange(tmp, inputField.getText().length());
				if(passwordLength >= 20)
					element[19] =(char) pm.twentyChange(tmp, inputField.getText().length());  //�Է��� �ڸ������� �޼ҵ带 �����Ѵ� 
				
				for(int i = 0; i < 20; i++)
					if(element[i] < 32)
					System.out.println((int) element[i]);
				element[0] =(char) ((element[0] % 10) + 48);  
				element[1] =(char) ((element[1] % 26) + 97);
				element[2] =(char) ((element[2] % 26) + 65);
				element[3] =(char) ((element[3] % 15) + 33); // ù 4�ڸ��� ������ ����,���ҹ���,���빮�� ,Ư�����ڰ� ���� �Ѵ� 
								
				stringTemp = String.valueOf(element);  //char�� String���� ��ȯ���ش� 
				password.setText(stringTemp);  // ������� �н����带 �ؽ�Ʈ���� �־��ش� 
			    StringSelection stringSelection = new StringSelection(stringTemp);
			    Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
			    clipboard.setContents(stringSelection, null);  // ��������� �ڵ����� Ŭ�����忡 ���簡 �ȴ� 

			    
			    stringTemp = inputField.getText();
				inputField.setText("");  
				inputNumberField.setText("0"); 
				for(i = 0; i < 20; i++)
					element[i]  = 0;
				}// �� �̿��� ������ �ٽ� �����·� ������Ų�� 
			}
			}
			@Override
			public void mouseEntered(MouseEvent e) {// ���콺�� ��ư������ ���� �̹����� Ŀ���� �ٲ�� 
				inputFinishButton.setIcon(inputFinishButtonEnteredImage);
				inputFinishButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // ���콺�� ��ư������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				inputFinishButton.setIcon(inputFinishButtonImage);
				inputFinishButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		
		koreanBackButton.addMouseListener(new MouseAdapter() {  //�ڷΰ��� ��ư�� ������ �� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) {  // �ڷΰ��� ��ư�� Ŭ���Ͽ��� �� 
				if(makeScreen == 0) { // ù ��° ȭ���̸� �����гη� ���ư��� 
				makeback = 1;
				koreanBackButton.setIcon(koreanBackButtonImage);
				koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				inputField.setText("");
				inputNumberField.setText("0");
				}
				if(makeScreen == 1) {  // �ι�° ȭ���̸� 1���� ȭ������ ���ư��� 
					inputField.setVisible(true);
					inputNumberField.setVisible(false);
					makeScreen = 0;
					koreanBackButton.setIcon(koreanBackButtonImage);
					koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				}
			}
			@Override
			public void mouseEntered(MouseEvent e) {  // ���콺�� ��ư ������ ���� �̹����� Ŀ���� �ٲ�� 
				koreanBackButton.setIcon(koreanBackButtonEnteredImage);
				koreanBackButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {  // ���콺�� ��ư ������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				koreanBackButton.setIcon(koreanBackButtonImage);
				koreanBackButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
	
		gomainButton.addMouseListener(new MouseAdapter() {   // �������� ���ư��� ��ư�� Ŭ�������� 
			public void mousePressed(MouseEvent e) {// ��ư�� Ŭ���Ͽ����� 
				makeback = 1;   // ����ȭ������ 
				gomainButton.setIcon(gomainButtonImage);  // ȭ������� ������ó�� ȭ���� �ٲ۴� 
				gomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
				backButton.setVisible(true);         
				inputField.setVisible(true);
				inputFinishButton.setVisible(true);
				koreanBackButton.setVisible(true);
				password.setVisible(false);
				gomainButton.setVisible(false);
				saveFileButton.setVisible(false); // �ٽ� �н����� ����� ��ư�� �������� ù��° ȭ���� ����� ������ �Ѵ� 
				makeScreen =0;
				passwordLength = 0;
			}
			@Override
			public void mouseEntered(MouseEvent e) {// ���콺�� ��ư ������ ���� �̹����� Ŀ���� �ٲ�� 
				gomainButton.setIcon(gomainButtonEnteredImage);
				gomainButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� ��ư ������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				gomainButton.setIcon(gomainButtonImage);
				gomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
	
		
		saveFileButton.addMouseListener(new MouseAdapter() {  //�����ϱ� ��ư�� ������ �� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) { // ��ư�� Ŭ���Ͽ��� �� 
				makeScreen = 3;  // �̹����� 4��° ȭ�鲬�� �ٲ��ش� 
			    password.setVisible(false);  // ������ �н����带 �Ⱥ��̰� �Ѵ� 
			    saveFileButton.setVisible(false); // �����ϱ� ��ư�� �Ⱥ��̰� �Ѵ� 
			    gomainButton.setVisible(false);   //  �������� ���� ��ư�� �Ⱥ��̰� �Ѵ� 
			    bigGomainButton.setVisible(true);  //  ����Ϸ��ϰ� �������� ���ư��� ��ư�� ���̰� �Ѵ� 
			    placeInputField.setVisible(true);   //  ��𿡼� �̿����� �Է��ϴ� �ؽ�Ʈ�ʵ带 ���̰� �Ѵ� 
				saveFileButton.setIcon(saveFileButtonImage);
				saveFileButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
			@Override
			public void mouseEntered(MouseEvent e) {// ���콺�� ��ư ������ ���� �̹����� Ŀ���� �ٲ�� 
				saveFileButton.setIcon(saveFileButtonEnteredImage);
				saveFileButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� ��ư ������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				saveFileButton.setIcon(saveFileButtonImage);
				saveFileButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		
		
		bigGomainButton.addMouseListener(new MouseAdapter() {    // �����ϰ� �������� ���ư��� ��ư�� �������� ���콺 �̺�Ʈ 
			public void mousePressed(MouseEvent e) {    // ���콺�� Ŭ���Ǿ��� �� �Ͼ �̺�Ʈ
				makeScreen = 0;   //  ȭ��0���� ��ȯ�Ѵ� 
				makeback = 1;  // ����ȭ������ ���� 
			    bigGomainButton.setVisible(false);   
			    placeInputField.setVisible(false);
				backButton.setVisible(true);
				inputField.setVisible(true);
				inputFinishButton.setVisible(true);
				koreanBackButton.setVisible(true);   //���ο��� �� ��ư ������ �� ù ȭ���� ������ �Ѵ� 
				inputField.setText("");
				inputNumberField.setText("0");         
			    try {                                  
					File outFile= new File("out.txt");       //���� ��ü�� ����� 
					if(!outFile.exists())outFile.createNewFile();  // ������ ������ ����� 
					BufferedWriter bw = new BufferedWriter(new FileWriter(outFile,true));  // ������ ���� ��ü�� ����� ���� ��ü�� �ִ´� 
					if(placeInputField.getText().equals(""))  // ��Ҹ� ���� �ʾ�����
						bw.write("����  : " + passwordLength + "    "+ "�н����� : " + stringTemp); // �н����常 ���Ͽ� ����ǰ� 
					else bw.write("����� ��� :  " + placeInputField.getText() + "    " + "����   :   " 
						+ passwordLength + "    "  + " �н�����  : " + stringTemp);  // �ƴϸ� ���, �н����尡 ����ȴ� 
					bw.newLine();  // �Է��ϰ� �ٹٲ۴� 
					bw.close();   // �Է� �Ϸ��� ���� �ݱ� 
				} catch (IOException e1) {
					e1.printStackTrace();
				}
			    placeInputField.setText("");
			    bigGomainButton.setIcon(bigGomainButtonImage);
			    bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));

			}
			@Override
			public void mouseEntered(MouseEvent e) {// ���콺�� ��ư ������ ���� �̹����� Ŀ���� �ٲ�� 
				bigGomainButton.setIcon(bigGomainButtonEnteredImage);
				bigGomainButton.setCursor(new Cursor(Cursor.HAND_CURSOR));
			}
			@Override
			public void mouseExited(MouseEvent e) {// ���콺�� ��ư ������ ������ �̹����� Ŀ���� �ǵ��ƿ´� 
				bigGomainButton.setIcon(bigGomainButtonImage);
				bigGomainButton.setCursor(new Cursor(Cursor.DEFAULT_CURSOR));
			}
		});
		this.add(backButton);
		this.add(exitButton);
		this.add(inputField);
		this.add(inputFinishButton);
		this.add(koreanBackButton);
		this.add(password);
		this.add(gomainButton);
		this.add(inputNumberField);
		this.add(saveFileButton);
		this.add(bigGomainButton);
		this.add(placeInputField);  // ������Ʈ���� �гο� �߰���Ų�� 
		password.setVisible(false);
		gomainButton.setVisible(false);
		inputNumberField.setVisible(false);
		saveFileButton.setVisible(false);
		bigGomainButton.setVisible(false);
		placeInputField.setVisible(false);  // ù ȭ�鿡 ���� �ʿ� ���� ������Ʈ���� setVisible(false)�Ѵ� 

	}
	
	
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		if(makeScreen ==0) {    // makeScreen�� ���ڰ� �޶����� �������� �̹����� �޶����� �ϰ� repaint�Ѵ� 
		g.drawImage(order, 100,150,null);
		repaint();
		}
		if(makeScreen == 1) {
			g.drawImage(numberOrder,100,150,null);
			repaint();
		}
		if(makeScreen ==2) {
		g.drawImage(finishText, 100,150,null);
		g.drawImage(passwordBackground,100,260,null);
		repaint();
		}
		if(makeScreen ==3) {
		g.drawImage(placeOrder, 100,150,null);
		repaint();
		}
	}
	
	
}
